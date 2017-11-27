using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS
{
    public partial class frmScholarshipclassfee :UserControlBase
    {
        school1 c = new school1();
        SqlDataReader DataReader;
        Boolean add_edit = false;
        static int f = 0;
        public void FillGrid()
        {
            dtgfeeheads.Rows.Clear();
            try
            {
                if (Convert.ToBoolean(Connection.GetExecuteScalar("SELECT COUNT(*) FROM tbl_schamount Where Classcode='" + cmbclass.SelectedValue + "' And sessioncode='" + school.CurrentSessionCode + "'")))
                {
                    DataReader = Connection.GetDataReader("select Pk_Id,Classcode,dbo.GetClassName(Classcode) as classname,Category,Amount from tbl_schamount Where sessioncode='" + school.CurrentSessionCode + "' AND Classcode='" + cmbclass.SelectedValue + "' ");
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            dtgfeeheads.Rows.Add(DataReader["Pk_Id"], DataReader["Classcode"],
                                DataReader["classname"], DataReader["Category"], DataReader["Amount"]);
                        }
                    }
                    DataReader.Close();
                }
                else
                {
                    DataReader = Connection.GetDataReader("select *from (select 1 as Pk_Id, 'GENERAL' as Category,0 as Amount union all select 2 as Pk_Id, 'OBC' as Category,0 as Amount union all select 3 as Pk_Id, 'SC' as Category,0 as Amount union all select 4 as Pk_Id, 'ST' as Category,0 as Amount)tbl");
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            dtgfeeheads.Rows.Add(DataReader["Pk_Id"], cmbclass.SelectedValue.ToString(),
                                cmbclass.Text.ToString(), DataReader["Category"], DataReader["Amount"]);
                        }
                    }
                    DataReader.Close();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public frmScholarshipclassfee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this); DesignForm.fromDesign1(this);
        }

        private void frmScholarshipclassfee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void frmScholarshipclassfee_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            f = 0;
            c.FillcomboBox("select classcode,classname from tbl_classmaster  order by classcode", "classname", "classcode", ref cmbclass);
            f = 1;
            cmbclass.SelectedIndex = 0;
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            cmbclass.Focus();
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (add_edit == true)
            {
                c.returnconn(c.myconn);
                SqlTransaction trn = c.myconn.BeginTransaction();
                do
                {

                    c.connectsql("insert into tbl_schamount (Classcode,Category,sessioncode,Amount) values ('" + cmbclass.SelectedValue + "','" + dtgfeeheads.Rows[i].Cells["Category"].Value + "','" + school.CurrentSessionCode + "','" + Convert.ToDecimal(dtgfeeheads.Rows[i].Cells["Amount"].Value) + "')", c.myconn, trn);
                    i++;
                }
                while (i < dtgfeeheads.Rows.Count);
                trn.Commit();
                MessageBox.Show("Data Saved..", "School");
                add_edit = false;
                c.GetMdiParent(this).EnableAllEditMenuButtons();
            }
            else
            {
                if (add_edit == false)
                {
                    SqlTransaction trn = c.myconn.BeginTransaction();
                    c.connectsql("delete from tbl_schamount where sessioncode='" + school.CurrentSessionCode + "' and  Classcode='" + cmbclass.SelectedValue + "'", c.myconn, trn);
                    do
                    {

                        c.connectsql("insert into tbl_schamount (Classcode,Category,sessioncode,Amount) values ('" + cmbclass.SelectedValue + "','" + dtgfeeheads.Rows[i].Cells["Category"].Value + "','" + school.CurrentSessionCode + "','" + Convert.ToDecimal(dtgfeeheads.Rows[i].Cells["Amount"].Value) + "')", c.myconn, trn);
                        i++;
                    }
                    while (i < dtgfeeheads.Rows.Count);
                    trn.Commit();
                    MessageBox.Show("Data Saved..", "School");
                    add_edit = false;
                    c.GetMdiParent(this).EnableAllEditMenuButtons();
                }
                DesignForm.fromDesign1(this);
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
        }

        private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(f==1)
            FillGrid();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbclass_Validating(object sender, CancelEventArgs e)
        {
            if (f == 1)
                FillGrid();
        }
    }
}
