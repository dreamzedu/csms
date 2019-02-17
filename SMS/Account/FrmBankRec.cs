using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace SMS.Account
{
    public partial class FrmBankRec :UserControlBase
    {
        public FrmBankRec()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        school1 c = new school1();

        Boolean add_edit = false;
        private void FrmBankRec_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            c.FillcomboBox("select * from tbl_account where actype=dbo.GetAccountCode('B') order by acname", "acname", "accode", ref valcmbbank);
            c.FillcomboBox("select * from tbl_account order by acname", "acname", "accode", ref valcmbaccountgroup);
            txtsession.Text = Convert.ToString(school.CurrentSessionCode);
            DesignForm.fromDesign1(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            dtgbook.Rows.Clear();
            dtp.Focus();
            DesignForm.fromDesign2(this);
            txtvoucherno.Enabled = false;
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtvoucherno.ReadOnly = false;
            txtvoucherno.Focus();
            DesignForm.fromDesign2(this);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (valcmbaccountgroup.SelectedValue == null || valcmbbank.SelectedValue == null || string.IsNullOrEmpty(valcmbaccountgroup.SelectedValue.ToString()) || string.IsNullOrEmpty(valcmbbank.SelectedValue.ToString()))
            {
                MessageBox.Show("Please select accounts. If you cannot see the accounts then you probably need to setup the account first.");
                return;
            }

            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter amount.");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter voucher narration.");
                return;
            }

            int bank1;
            int bank2;
            bank1 = Convert.ToInt16(valcmbaccountgroup.SelectedValue);
            bank2 = Convert.ToInt16(valcmbbank.SelectedValue);

            
            if (bank1 == bank2)
            {
                MessageBox.Show("Both Accounts are same...");
                goto mline;
            }
            txtvchtype.Text = "BR";
            txtsession.Text = Convert.ToString(school.CurrentSessionCode);
            if (add_edit == true)
            {
                c.returnconn(c.myconn);
                SqlCommand command = new SqlCommand("select max(vchno) from tbl_voucher where  sessioncode=" + txtsession.Text + " and  vchtype='" + txtvchtype.Text + "'", c.myconn);
                command.CommandTimeout = 120;
                Int32 mstudentno;
                mstudentno = 1000001;
                if (command.ExecuteScalar() != System.DBNull.Value)
                {
                    mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                }
                txtvoucherno.Text = mstudentno.ToString();
                c.insertdata("tbl_voucher", c.myconn, this);
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                string mysql;
                int i = 0;
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbbank.SelectedValue + "," + textBox1.Text + ",'" + dtp.Value.Date + "','Dr')";
                c.connectsql(mysql, c.myconn, trn);
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbaccountgroup.SelectedValue + "," + textBox1.Text + ",'" + dtp.Value.Date + "','Cr')";
                c.connectsql(mysql, c.myconn, trn);
                if (dtgbook.Rows.Count > 0)
                {
                    while (i <= dtgbook.Rows.Count - 1)
                    {
                        double mval = Convert.ToDouble(dtgbook.Rows[i].Cells[2].Value);
                        if (mval > 0)
                        {
                            mysql = "insert into tbl_subledger (sessioncode,vchtype,vchno,accode,subledgercode,subledgamt,vchdate,amttype,narration) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbaccountgroup.SelectedValue + "," + dtgbook.Rows[i].Cells[0].Value + "," + mval + ",'" + dtp.Value.Date + "','Cr','" + dtgbook.Rows[i].Cells[3].Value + "')";
                            c.connectsql(mysql, c.myconn, trn);
                        }
                        i++;
                    }
                }
                trn.Commit();
                DesignForm.fromDesign1(this);
            }
            if (add_edit == false)
            {
                c.returnconn(c.myconn);
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                //*--delete prvious voucher-------------
                c.connectsql("delete from tbl_voucher where sessioncode=" + txtsession.Text + " and vchtype='BR'  and vchno=" + txtvoucherno.Text, c.myconn, trn);
                trn.Commit();
                c.insertdata("tbl_voucher", c.myconn, this);
                trn = c.myconn.BeginTransaction();
                //*--delete prvious voucher-------------
                c.connectsql("delete from tbl_voucherdet where sessioncode=" + txtsession.Text + " and vchtype='BR' and amttype='Dr' and vchno=" + txtvoucherno.Text, c.myconn, trn);
                c.connectsql("delete from tbl_voucherdet where sessioncode=" + txtsession.Text + " and vchtype='BR' and amttype='Cr' and vchno=" + txtvoucherno.Text, c.myconn, trn);
                c.connectsql("delete from tbl_subledger where sessioncode=" + txtsession.Text + " and vchtype='BR' and amttype='Cr' and vchno=" + txtvoucherno.Text, c.myconn, trn);

                //*------------------
                string mysql;
                int i = 0;
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbbank.SelectedValue + "," + textBox1.Text + ",'" + dtp.Value.Date + "','Dr')";
                c.connectsql(mysql, c.myconn, trn);
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbaccountgroup.SelectedValue + "," + textBox1.Text + ",'" + dtp.Value.Date + "','Cr')";
                c.connectsql(mysql, c.myconn, trn);
                if (dtgbook.Rows.Count > 0)
                {
                    while (i <= dtgbook.Rows.Count - 1)
                    {
                        double mval = Convert.ToDouble(dtgbook.Rows[i].Cells[2].Value);
                        if (mval > 0)
                        {
                            mysql = "insert into tbl_subledger (sessioncode,vchtype,vchno,accode,subledgercode,subledgamt,vchdate,amttype,narration) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbaccountgroup.SelectedValue + "," + dtgbook.Rows[i].Cells[0].Value + "," + mval + ",'" + dtp.Value.Date + "','Cr','" + dtgbook.Rows[i].Cells[3].Value + "')";
                            c.connectsql(mysql, c.myconn, trn);
                        }
                        i++;
                    }
                }
                trn.Commit();
                DesignForm.fromDesign1(this);
            }
            MessageBox.Show("Record Saved...", "School");
        mline:
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
        }

        private void dtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            DesignForm.fromDesign1(this);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void txtvoucherno_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtvoucherno.Text.Trim() != string.Empty)
                {
                    c.returnconn(c.myconn);
                    txtsession.Text = Convert.ToString(school.CurrentSessionCode);
                    string mysql;
                    mysql = "select * from tbl_voucher where sessioncode=" + txtsession.Text + " and  vchtype='BR' and vchno=" + txtvoucherno.Text;
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    SqlDataReader reader = com.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        dtp.Value = Convert.ToDateTime(reader["vchdate"]);
                        txtvchtype.Text = Convert.ToString(reader["vchtype"]);
                        textBox2.Text = Convert.ToString(reader["remark"]);
                        txtsession.Text = Convert.ToString(reader["sessioncode"]);
                        reader.Close();
                        mysql = "select * from tbl_voucherdet where sessioncode=" + txtsession.Text + " and vchtype='BR' and vchno=" + txtvoucherno.Text;
                        com = new SqlCommand(mysql, c.myconn);
                        reader = com.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string amttype;
                                amttype = Convert.ToString(reader["amttype"]);
                                if (amttype == "Cr")
                                {
                                    valcmbaccountgroup.SelectedValue = Convert.ToInt16(reader["accode"]);
                                    Decimal numb = Convert.ToDecimal(reader["vchamt"]);
                                    textBox1.Text = numb.ToString("0.00");

                                    //textBox1.Text =  textBox1.Text.ToString("0.00",CultureInfo.InvariantCulture ); 
                                }
                                else
                                {
                                    valcmbbank.SelectedValue = Convert.ToInt16(reader["accode"]);
                                }
                            }
                            reader.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Voucher Not Found..");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); throw ex;
            }

        }

        private void valcmbaccountgroup_Validated(object sender, EventArgs e)
        {
            c.returnconn(c.myconn);
            txtsession.Text = Convert.ToString(school.CurrentSessionCode);
            string mysql;
            mysql = "select a.*,b.acname from tbl_subledger_account a,tbl_account b where a.subledgercode=b.accode and a.accode=" + valcmbaccountgroup.SelectedValue;
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            SqlDataReader reader = com.ExecuteReader();
            int i = 0;
            dtgbook.Rows.Clear();
            if (reader.HasRows == true)
                while (reader.Read())
                {
                    dtgbook.Rows.Add();
                    dtgbook.Rows[i].Cells[0].Value = reader["subledgercode"];
                    dtgbook.Rows[i].Cells[1].Value = reader["acname"];
                    i++;
                }
            reader.Close();
        }

        private void dtgbook_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                dtgbook.EndEdit();
                decimal amt = 0;
                if (e.ColumnIndex == 2)
                {
                    dtgbook.EndEdit();
                    if (Convert.ToString(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == string.Empty)
                    {
                    }
                    else
                    {
                        for (int i = 0; i <= dtgbook.Rows.Count - 1; i++)
                        {
                            amt = amt + Convert.ToDecimal(dtgbook.Rows[i].Cells[e.ColumnIndex].Value);
                        }
                        textBox1.Text = Convert.ToString(amt);

                        dtgbook.Refresh();
                    }
                }
            }
            catch
            {
            }
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet("select (select top 1 logoimage from tbl_school ) as SLogo,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,convert(nvarchar(20), v.vchdate,103) as vchdate,v.vchno,v.Remark,vd.vchamt,dbo.GetAccountName(vd.accode) as AcName,dbo.GetAccountName((select top 1 ivd.accode from tbl_voucherdet ivd where ivd.vchno=vd.vchno and ivd.amttype='Dr' and ivd.vchtype='BR')) as BName from tbl_voucher v inner join tbl_voucherdet vd on v.vchtype=vd.vchtype and v.vchno=vd.vchno where amttype='Cr' and vd.vchtype='BR' and vd.vchno='" + txtvoucherno.Text.Trim() + "'");
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankRec.xsd");
                //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                Account.ReportDesign.BankReceipt cr = new Account.ReportDesign.BankReceipt();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                s.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); throw ex;
            }
        }

        private void FrmBankRec_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
