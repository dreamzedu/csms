using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmuserauth :UserControlBase
    {
        school1 c = new school1();
        Int32 mstudentno;
        public frmuserauth()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
            
        }
        public void chk()
        {

            MDIParent1 m = (MDIParent1)this.FindForm();
            //foreach (ToolStripMenuItem s in m.menuStrip.Items)
            //{
            //    chkListMenu.Items.Add(s.Text + "-" + s.Tag);
            //}
            foreach (ToolStripMenuItem s in m.menuStrip.Items)
            {
                if (s.Tag.ToString().Trim().Equals(""))
                {
                }
                else
                {
                    chkListMenu.Items.Add(s.Tag.ToString().Trim());
                }
            }
        }
        public void chk1(string s1, bool flage)
        {
            MDIParent1 m = (MDIParent1)this.FindForm();
            if (flage)
            {
                foreach (ToolStripMenuItem s in m.menuStrip.Items)
                {
                    if (s1.Trim().Equals(s.Tag.ToString().Trim()))
                    {
                        int ts = 0;
                        if (s1.Equals("USER"))
                        {
                            ts = s.DropDownItems.Count - 1;
                        }
                        else
                        {
                            ts = s.DropDownItems.Count;
                        }
                        for (int k = 0; k < ts; k++)
                        {
                            if (s.DropDownItems[k].Tag != null && s.DropDownItems[k].Tag != "$$$$$$$$$$")
                                chkListSubMenu.Items.Add(s.DropDownItems[k].Tag.ToString().Trim());
                        }
                    }
                }
            }
            else
            {
                foreach (ToolStripMenuItem s in m.menuStrip.Items)
                {
                    foreach (ToolStripMenuItem s2 in s.DropDownItems)
                    {
                        if (!string.IsNullOrEmpty(s2.Tag.ToString()))
                        {
                            if (s1.Trim().Equals(s2.Tag.ToString().Trim()))
                            {
                                for (int k = 0; k < s2.DropDownItems.Count; k++)
                                {
                                    if (s2.DropDownItems[k].Tag != null && s2.DropDownItems[k].Tag != "$$$$$$$$$$")
                                        chkListASubMenu.Items.Add(s2.DropDownItems[k].Tag.ToString().Trim());
                                }
                            }
                        }
                    }
                }
            }
        }
        private void frmuserauth_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleSaveButton(true);
            chk();
            c.getconnstr();
            //c.FillcomboBox("select * from tbl_user Where UserCode<>1001 order by username", "username", "usercode", ref cmbUser);
            c.FillcomboBox("select * from MasterUser order by userId",Connection.GetUserDbConnection(), "userId", "usercode", ref cmbUser);
            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select count(*) from tbl_menu", c.myconn);
            command.CommandTimeout = 120;
            mstudentno = 1;
            if (command.ExecuteScalar() != System.DBNull.Value)
            {
                mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }

            string[] myList = new string[mstudentno - 1];

            command = new SqlCommand("select * from tbl_menu order by menutag", c.myconn);
            SqlDataReader reader;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    myList[i] = Convert.ToString(reader["menudesc"]);
                    i++;
                }
            }
            reader.Close();
            lstsubject.Items.AddRange(myList);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            int[] mytag = new int[mstudentno - 1];
            SqlCommand command = new SqlCommand("select * from tbl_menu order by menutag", c.myconn);
            SqlDataReader reader;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    mytag[i] = Convert.ToInt16(reader["menutag"]);
                    i++;
                }
            }
            reader.Close();
            c.returnconn(c.myconn);
            //int i = lstsubject.Items.Count - 1;
            int j = 0;
            SqlTransaction trn;
            trn = c.myconn.BeginTransaction();
            string str4 = "delete from tbl_Userauth where usercode='" + cmbUser.SelectedValue + "'";
            c.connectsql(str4, c.myconn, trn);

            foreach (int indexChecked in chkListMenu.CheckedIndices)
            {
                string mysql = "";
                //   mysql = "insert into tbl_userauth (usercode,menucode) values (" + valcmbclass.SelectedValue  + "," + mytag[indexChecked]  + ")";
                mysql = "insert into tbl_userauth (usercode,menucode) values ('" + cmbUser.SelectedValue + "','" + chkListMenu.Items[indexChecked].ToString().Trim() + "')";
                c.connectsql(mysql, c.myconn, trn);
            }

            foreach (int indexChecked in chkListSubMenu.CheckedIndices)
            {
                string mysql = ""; 
                //   mysql = "insert into tbl_userauth (usercode,menucode) values (" + valcmbclass.SelectedValue  + "," + mytag[indexChecked]  + ")";
                mysql = "insert into tbl_userauth (usercode,menucode) values ('" + cmbUser.SelectedValue + "','" + chkListSubMenu.Items[indexChecked].ToString().Trim () + "')";
                c.connectsql(mysql, c.myconn, trn);
            }

            foreach (int indexChecked in chkListASubMenu.CheckedIndices)
            {
                string mysql = "";
                //   mysql = "insert into tbl_userauth (usercode,menucode) values (" + valcmbclass.SelectedValue  + "," + mytag[indexChecked]  + ")";
                mysql = "insert into tbl_userauth (usercode,menucode) values ('" + cmbUser.SelectedValue + "','" + chkListASubMenu.Items[indexChecked].ToString().Trim() + "')";
                c.connectsql(mysql, c.myconn, trn);
            }
            trn.Commit();
            MessageBox.Show("Authorization Saved..");
            //this.Close();
        }

        private void valcmbclass_Validated(object sender, EventArgs e)
        {
            //fill tag property
            int[] mytag = new int[mstudentno - 1];
            SqlCommand command = new SqlCommand("select * from tbl_menu order by menutag", c.myconn);
            SqlDataReader reader;
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    mytag[i] = Convert.ToInt16(reader["menutag"]);
                    i++;
                }
            }
            reader.Close();
            c.returnconn(c.myconn);
            //check the tag

            command = new SqlCommand("select * from tbl_menu order by menutag", c.myconn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    mytag[i] = Convert.ToInt16(reader["menutag"]);
                    i++;
                }
            }
            reader.Close();
            c.returnconn(c.myconn);
            //-----------------------------------------------
            for (int i = 0; i <= lstsubject.Items.Count - 1; i++)
            {
                {
                    lstsubject.SetItemChecked(i, false);
                }
            }

            command = new SqlCommand("select * from tbl_userauth where usercode=" + cmbUser.SelectedValue + "  order by menucode", c.myconn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < lstsubject.Items.Count; i++)
                    {
                        if (mytag[i] == Convert.ToInt16(reader["menucode"]))
                        {
                            lstsubject.SetItemChecked(i, true);
                        }
                    }
                }
            }
            //-------------------------------------------
            reader.Close();
            c.returnconn(c.myconn);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
         
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  checkedListBox1.Items.Clear();
            //       string curItem = listBox1.SelectedItem.ToString();
            //  MessageBox.Show(curItem); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("Select menucode from tbl_userauth where usercode='" + cmbUser.SelectedValue + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int s = 0; s < ds.Tables[0].Rows.Count; s++)
                {
                    string MenuCode = string.Empty;
                    for (int i = 0; i < (chkListMenu.Items.Count); i++)
                    {
                        if (chkListMenu.GetItemChecked(i))
                        {
                            MenuCode = chkListMenu.Items[i].ToString().Trim();
                        }
                        else
                        {
                            MenuCode = chkListMenu.Items[i].ToString().Trim();
                            if (MenuCode == ds.Tables[0].Rows[s].ItemArray[0].ToString().Trim())
                            {
                                chkListMenu.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                chkListSubMenu.Items.Clear();
                for (int i = 0; i < (chkListMenu.Items.Count); i++)
                {
                    if (chkListMenu.GetItemChecked(i))
                    {
                        chk1(chkListMenu.Items[i].ToString().Trim(), true);
                    }
                }

                for (int s = 0; s < ds.Tables[0].Rows.Count; s++)
                {
                    string MenuCode = string.Empty;
                    for (int i = 0; i <= (chkListSubMenu.Items.Count - 1); i++)
                    {
                        if (chkListSubMenu.GetItemChecked(i))
                        {
                            MenuCode = chkListSubMenu.Items[i].ToString().Trim();
                        }
                        else
                        {
                            MenuCode = chkListSubMenu.Items[i].ToString().Trim();
                            if (MenuCode.ToString().Trim() == ds.Tables[0].Rows[s].ItemArray[0].ToString().Trim())
                            {
                                chkListSubMenu.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                chkListASubMenu.Items.Clear();
                for (int i = 0; i < (chkListSubMenu.Items.Count); i++)
                {
                    if (chkListSubMenu.GetItemChecked(i))
                    {
                        chk1(chkListSubMenu.Items[i].ToString().Trim(), false);
                    }
                }

                for (int s = 0; s < ds.Tables[0].Rows.Count; s++)
                {
                    string MenuCode = string.Empty;
                    for (int i = 0; i <= (chkListASubMenu.Items.Count - 1); i++)
                    {
                        if (chkListASubMenu.GetItemChecked(i))
                        {
                            MenuCode = chkListASubMenu.Items[i].ToString().Trim();
                        }
                        else
                        {
                            MenuCode = chkListASubMenu.Items[i].ToString().Trim();
                            if (MenuCode.ToString().Trim() == ds.Tables[0].Rows[s].ItemArray[0].ToString().Trim())
                            {
                                chkListASubMenu.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chkListSubMenu.Items.Clear();
            for (int i = 0; i < (chkListMenu.Items.Count); i++)
            {
                if (chkListMenu.GetItemChecked(i))  
                {
                       chk1(chkListMenu.Items[i].ToString().Trim(), true); 
                }
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (chkListSubMenu.Items.Count); i++)
            {

                if (chkListSubMenu.GetItemChecked(i))
                {

                }
                else
                {
                    chkListSubMenu.SetItemChecked(i, true);
                }
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (chkListMenu.Items.Count); i++)
            {
                if (chkListMenu.GetItemChecked(i))
                {
                }
                else
                {
                    chkListMenu.SetItemChecked(i, true);
                }
            }
        }

        private void btnCancelAll1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListMenu .Items.Count; i++)
            {
                chkListMenu.SetItemChecked(i, false);
            }
            chkListASubMenu.Items.Clear();
            chkListSubMenu.Items.Clear();
        }

        private void btnCancelAll2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListSubMenu.Items.Count; i++)
            {
                chkListSubMenu.SetItemChecked(i, false);
            }
            chkListASubMenu.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chkListASubMenu.Items.Clear();
            for (int i = 0; i < (chkListSubMenu.Items.Count); i++)
            {
                if (chkListSubMenu.GetItemChecked(i))
                {
                    chk1(chkListSubMenu.Items[i].ToString().Trim(), false);
                }
            }
        }

        private void btnASubMenucncl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListASubMenu.Items.Count; i++)
            {
                chkListASubMenu.SetItemChecked(i, false);
            }
        }

        private void btnASubAllSele_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListASubMenu.Items.Count; i++)
            {
                chkListASubMenu.SetItemChecked(i, true);
            }
        }

        private void frmuserauth_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);
        }
         
       
    }
}



