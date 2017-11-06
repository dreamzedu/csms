using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmCCESkills :UserControlBase
    {
        SqlDataReader dataReader = null;
        school1 c1 = new school1();
        public frmCCESkills()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmCCESkills_Load(object sender, EventArgs e)
        {
            dtgSkills.Columns.Clear();
            dtgSkills.Rows.Clear();
            dataReader = Connection.GetDataReader("SELECT SkillId, SkillName, Status FROM tbl_CCESkills Order By SkillId");
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dtgSkills.Columns.Add(dataReader["SkillId"].ToString(), dataReader["SkillName"].ToString());
                    dtgSkills.Columns[dataReader["SkillId"].ToString()].Width = 150;
                }
                dataReader.Close();
            }
            if (Convert.ToInt32(Connection.GetExecuteScalar("Select Count(*) From tbl_CCESubSkills")) > 0)
            {
                int Counter = 0; DataTable dt = new DataTable("dt");

                int MaxRowNumber = Convert.ToInt32(Connection.GetExecuteScalar("Select MAX(Num) as MaxRow  From (Select Count(v.SkillId) As Num From  " +
                    " (Select s1.SkillId ,s1.SkillName ,s2 .SubSkillId ,s2.Discription From tbl_CCESkills s1, tbl_CCESubSkills s2  " +
                    "  Where s1.SkillId =s2.SkillId) v Group By v.SkillId) t"));

                DataTable dtSubSkillDetail = Connection.GetDataTable(" Select s1.SkillId ,s1.SkillName ,s2 .SubSkillId ,s2.Discription  From  " +
                     " tbl_CCESkills s1, tbl_CCESubSkills s2 Where s1.SkillId =s2.SkillId  Order By s1.SkillId");

                foreach (DataGridViewColumn c in dtgSkills.Columns)
                    dt.Columns.Add(c.Name);

                while (MaxRowNumber > Counter)
                {
                    dt.Rows.Add(dt.NewRow());
                    Counter++; 
                }
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    Counter = 0;
                    DataRow[] Rows = dtSubSkillDetail.Select("SkillId='" + dt.Columns[c].ColumnName + "'");
                    if (Rows.Length > 0)
                    {
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            if (r < Rows.Length && r <= Rows.Length)
                                dt.Rows[r][c] = Rows[r]["Discription"];
                        }
                    }
                }
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    dtgSkills.Rows.Add();
                    for (int s = 0; s < dt.Columns.Count; s++)
                    {
                        DataGridViewRow ro = dtgSkills.Rows[r];
                        ro.Cells[s].Value = dt.Rows[r][s].ToString();
                    }
                   
                }
            }

            c1.GetMdiParent(this).ToggleEditButton(true);
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void dtgSkills_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dtgSkills .Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            c1.GetMdiParent(this).ToggleSaveButton(true);
            dtgSkills.Enabled = true;
           dtgSkills.Focus();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (dtgSkills.RowCount > 1)
            {
                string cmdText = string.Empty;
                SqlTransaction trn = null;
                int SubSkillId = 1001;
                trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    cmdText = " Truncate Table tbl_CCESubSkills ";
                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                    foreach (DataGridViewRow r in dtgSkills.Rows)
                    {
                        if (dtgSkills.RowCount - 1 > r.Index)
                            foreach (DataGridViewColumn c in dtgSkills.Columns)
                            {
                                if (r.Cells[c.Name].Value != null && r.Cells[c.Name].Value != "")
                                {
                                    if (r.Cells[c.Name].Value.ToString().Length > 0)
                                    {
                                        cmdText = "Insert Into tbl_CCESubSkills(SkillId, SubSkillId, Discription, Status) " +
                                            " Values('" + c.Name + "','" + (SubSkillId++) + "','" + r.Cells[c.Name].Value + "',1)";
                                        Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                                    }
                                }
                            }
                    }
                    trn.Commit();
                    MessageBox.Show("Saved Successfully.");
                }
                catch
                {
                    trn.Rollback();
                    MessageBox.Show("Some Record Missing.\n\tPlease Check Records.");
                }

                c1.GetMdiParent(this).ToggleSaveButton(false);
                dtgSkills.Enabled = false; 
                
            }
            else
            {
                MessageBox.Show("Please Fill Records Carefully.");
                dtgSkills.Focus();
            }
        }

        private void frmCCESkills_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
