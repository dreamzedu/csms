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
    public partial class FrmJournalVoucher :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        DataSet ds;
        public FrmJournalVoucher()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void FrmJournalVoucher_Load(object sender, EventArgs e)
        {

            c.GetMdiParent(this).EnableAllEditMenuButtons();

            c.getconnstr();
            ds = new DataSet();
            ds = c.GetDataSet("select accode,acname from  tbl_account");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DStbl_account.xsd");
            c.FillcomboBox("select acname,accode from tbl_account  order by acname", "acname", "accode", ref valcmbbank);
            //c.FillcomboBox("select * from tbl_account order by acname", "acname", "accode", ref valcmbaccountgroup);
            txtsession.Text = Convert.ToString(school.CurrentSessionCode);
            for (int i = 0; i <= 25; i++)
            {
                dtgbook.Rows.Add();
                DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dtgbook.Rows[i].Cells[0]);
                ComboColumn.DisplayMember = "acname";
                ComboColumn.ValueMember = "accode";
                ComboColumn.DataSource = ds.Tables[0];

           }
            DesignForm.fromDesign1(this);
           
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            dtp.Focus();
            dtgbook.Rows.Clear();
            for (int i = 0; i <= 25; i++)
            {

                dtgbook.Rows.Add();
                DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dtgbook.Rows[i].Cells[0]);
                ComboColumn.DisplayMember = "acname";
                ComboColumn.ValueMember = "accode";
                ComboColumn.DataSource = ds.Tables[0];
            }
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
            int bank1 = 0;
            int bank2 = 0;
            //bank1 = Convert.ToInt16(valcmbaccountgroup.SelectedValue);
            bank2 = Convert.ToInt16(valcmbbank.SelectedValue);
            if (bank1 == bank2)
            {
                MessageBox.Show("Both Accounts are same...");
                goto mline;
            }
            txtRefNo.Text=txtvchtype.Text = "JV";
            txtsession.Text = Convert.ToString(school.CurrentSessionCode);
            if (add_edit == true)
            {
                c.returnconn(c.myconn);
                SqlCommand command = new SqlCommand("select max(vchno) from tbl_voucher where   sessioncode=" + txtsession.Text + " and  vchtype='" + txtvchtype.Text + "' and RefNo='JV'", c.myconn);
                command.CommandTimeout = 120;
                Int32 mstudentno;
                mstudentno = 10001;
                if (command.ExecuteScalar() != System.DBNull.Value)
                {
                    mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                }
                   txtvoucherno.Text = mstudentno.ToString();
                
                c.insertdata("tbl_voucher", c.myconn, this);
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                string mysql;
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbbank.SelectedValue + "," + txtvchamt.Text + ",'" + dtp.Value.Date + "','" + strcmbdrcr.Text + "','S')";
                c.connectsql(mysql, c.myconn, trn);
                //----------------------------
                string amttype = strcmbdrcr.Text;
                if (amttype == "Cr")
                {
                    amttype = "Dr";
                }
                else
                {
                    amttype = "Cr";
                }
                for (int i = 0; i <= dtgbook.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(dtgbook.Rows[i].Cells[1].Value) > 0)
                    {
                        mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + dtgbook.Rows[i].Cells[0].Value + "," + Convert.ToDecimal(dtgbook.Rows[i].Cells[1].Value) + ",'" + dtp.Value.Date + "','" + amttype + "','M')";
                        c.connectsql(mysql, c.myconn, trn);
                    }
                }
                trn.Commit();
                DesignForm.fromDesign1(this);
            }
            if (add_edit == false)
            {
                c.updatedata("tbl_voucher", c.myconn, this, "vchno", txtvoucherno.Text);
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                //*--delete prvious voucher-------------
                c.connectsql("delete from tbl_voucherdet where sessioncode=" + txtsession.Text + " and vchtype='JV' and amttype='Cr' and vchno=" + txtvoucherno.Text, c.myconn, trn);
                c.connectsql("delete from tbl_voucherdet where sessioncode=" + txtsession.Text + " and vchtype='JV' and amttype='Dr' and vchno=" + txtvoucherno.Text, c.myconn, trn);
                //*------------------
                string mysql;
                mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + valcmbbank.SelectedValue + "," + txtvchamt.Text + ",'" + dtp.Value.Date + "','" + strcmbdrcr.Text + "','S')";
                c.connectsql(mysql, c.myconn, trn);
                //----------------------------
                string amttype = strcmbdrcr.Text;
                if (amttype == "Cr")
                {
                    amttype = "Dr";
                }
                else
                {
                    amttype = "Cr";
                }
                for (int i = 0; i <= dtgbook.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(dtgbook.Rows[i].Cells[1].Value) > 0)
                    {
                        mysql = "insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" + txtsession.Text + "','" + txtvchtype.Text + "'," + txtvoucherno.Text + "," + dtgbook.Rows[i].Cells[0].Value + "," + Convert.ToDecimal(dtgbook.Rows[i].Cells[1].Value) + ",'" + dtp.Value.Date + "','" + amttype + "','M')";
                        c.connectsql(mysql, c.myconn, trn);
                    }
                }
                //c.connectsql(mysql, c.myconn, trn);
                trn.Commit();
                DesignForm.fromDesign1(this);
            }
            MessageBox.Show("Record Saved...", "School");
        mline:
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            dtgbook.Rows.Clear();
            for (int i = 0; i <= 25; i++)
            {
                dtgbook.Rows.Add();
            }
            DesignForm.fromDesign1(this);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void dtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
            }
        }

        private void txtvoucherno_Validated(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Trim() != string.Empty)
            {
                c.returnconn(c.myconn);
                txtsession.Text = Convert.ToString(school.CurrentSessionCode);
                string mysql;
                if (txtvoucherno.Text.Trim() == string.Empty)
                    txtvoucherno.Text = "0";
                mysql = "select * from tbl_voucher where  vchtype='JV' and VchNo in ( select VchNo from tbl_voucherdet vd inner join  tbl_account ac on vd.accode=ac.accode where   vd.VchNo='" + txtvoucherno.Text.Trim() + "' and type='M')";
                SqlCommand com;
                ds = new DataSet();
                ds = c.GetDataSet("select accode,acname from  tbl_account");
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
                    mysql = "select * from tbl_voucherdet where type='S' and sessioncode=" + txtsession.Text + " and vchtype='JV' and vchno=" + txtvoucherno.Text;
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string amttype;
                        amttype = Convert.ToString(reader["amttype"]);
                        valcmbbank.SelectedValue = Convert.ToInt16(reader["accode"]);
                        strcmbdrcr.Text = amttype;
                        Decimal numb = Convert.ToDecimal(reader["vchamt"]);
                        txtvchamt.Text = numb.ToString("0.00");
                    }
                    reader.Close();
                    mysql = "select * from tbl_voucherdet where type='M' and sessioncode=" + txtsession.Text + " and vchtype='JV' and vchno=" + txtvoucherno.Text;
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dtgbook.Rows.Clear();
                        i = 0;
                        while (reader.Read())
                        {
                            dtgbook.Rows.Add();

                            DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dtgbook.Rows[i].Cells[0]);
                            ComboColumn.DisplayMember = "acname";
                            ComboColumn.ValueMember = "accode";
                            ComboColumn.DataSource = ds.Tables[0];
                            dtgbook.Rows[i].Cells[0].Value = reader["accode"];
                            dtgbook.Rows[i].Cells[1].Value = reader["vchamt"];
                            i++;
                        }
                        while (i <= 25)
                        {
                            dtgbook.Rows.Add();
                            DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dtgbook.Rows[i].Cells[0]);
                            ComboColumn.DisplayMember = "acname";
                            ComboColumn.ValueMember = "accode";
                            ComboColumn.DataSource = ds.Tables[0];
                            i++;
                        }
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Voucher Not Found..");
                }
            }
        }

        private void dtgbook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F3")
            {
                
                dtgbook.Rows.Add();
                ds = new DataSet();
                ds = c.GetDataSet("select accode,acname from  tbl_account");
                DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dtgbook.Rows[dtgbook.CurrentCell.RowIndex].Cells[0]);
                ComboColumn.DisplayMember = "acname";
                ComboColumn.ValueMember = "accode";
                ComboColumn.DataSource = ds.Tables[0];

            }
            if (e.KeyCode.ToString() == "F8")
            {
                dtgbook.Rows.RemoveAt(dtgbook.CurrentCell.RowIndex);
            }
        }

        private void dtgbook_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                dtgbook.EndEdit();
                int accode1 = Convert.ToInt16(valcmbbank.SelectedValue);
                int accode2 = 0;
                if (e.ColumnIndex == 0)
                {
                    accode2 = Convert.ToInt16(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (accode1 == accode2)
                    {
                        MessageBox.Show("Debit/Credit Accounts are Same..");
                        e.Cancel = true;
                    }
                }
                decimal amt = 0;
                if (e.ColumnIndex == 1)
                {
                    dtgbook.EndEdit();
                    if (Convert.ToString(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "")
                    {
                    }
                    else
                    {
                        for (int i = 0; i <= dtgbook.Rows.Count - 1; i++)
                        {
                            amt = amt + Convert.ToInt16(dtgbook.Rows[i].Cells[e.ColumnIndex].Value);
                        }
                        txtvchamt.Text = Convert.ToString(amt);
                        //if (e.RowIndex == dtgbook.Rows.Count - 1)
                        //{
                        //    dtgbook.Rows.Add();
                        //}
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
                ds = Connection.GetDataSet("GetCurrentJVoucher '" + txtvoucherno.Text.Trim() + "'");
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\CJournal.xsd");
                //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                Account.ReportDesign.IJournalBook cr = new Account.ReportDesign.IJournalBook();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                s.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmJournalVoucher_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        
    }
}
