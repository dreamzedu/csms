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
    public partial class frmclass :UserControlBase
    {
        school1 c = new school1();
        string classno;

        Boolean add_edit = false;
        public frmclass()
        {
            InitializeComponent();
            DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            textBox1.Text = "";
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            valcmbclass.Focus();
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        private void frmclass_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
                c.getconnstr();
                

                c.FillcomboBox("select * from tbl_classmaster order by ClassOrder", "classname", "classcode", ref  valcmbclass);

                c.FillcomboBox("select * from tbl_section order by sectionname", "sectionname", "sectioncode", ref  valcmbsection);
                // c.FillcomboBox("select * from tbl_sankay order by sankayname", "sankayname", "sankaycode", ref valcmbsankay);
                c.FillListBox("select a.classno,b.classname+' '+c.sectionname   as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode order by a.classcode,c.sectioncode", "class", "classno", ref listBox1);
                //MessageBox.Show(c.myconn.ConnectionString);  
                valcmbsankay.SelectedIndex = 0;       
           
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            string CText = string.Empty;
            foreach (System.Data.DataRowView item in listBox1.SelectedItems)
            {
                CText += item.Row.Field<String>(1);
            }
            var value = CText.Split(' ').ToList();

            int k = Connection.Login("select count(*) from tbl_classstudent where classno ='" + valcmbclass.SelectedValue.ToString() + "' and section=(select top 1 sectioncode from tbl_section where sectionname='" + value[1].ToString() + "')");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Record.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete   FROM  tbl_class where classno='" + listBox1.SelectedValue.ToString() + "'");
                    MessageBox.Show("Record Deleted.");
                    c.FillListBox("select a.classno,b.classname+' '+c.sectionname   as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode order by a.classcode,c.sectioncode", "class", "classno", ref listBox1);
                    //Connection.AllPerform("Delete from tbl_section where sectioncode ='" + valcmbsection.SelectedValue.ToString() + "'");
                    //Connection.AllPerform("Delete from tbl_sankay where sankaycode ='" + valcmbsankay.SelectedValue.ToString() + "'");
                   DesignForm.fromClear(this);
                }
            }
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();


        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Strenght Null Value Not Allowed.");

            }
            else
            {
                if (valcmbclass.SelectedIndex == 0)
                {
                    valcmbclass.SelectedIndex = 0;
                }
                if (valcmbsankay.SelectedIndex == 0)
                {
                    valcmbsankay.SelectedIndex = 0;
                }
                if (valcmbsection.SelectedIndex == 0)
                {
                    valcmbsection.SelectedIndex = 0;
                }
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(classno) from tbl_class", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_class where sectioncode='" + valcmbsection .SelectedValue.ToString () + "' and classcode='"+valcmbclass.SelectedValue.ToString ()+"' and sankaycode ='"+valcmbsankay .SelectedValue .ToString () +"'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtclasscode.Text = mstudentno.ToString();
                        c.insertdata("tbl_class", c.myconn, this);
                        MessageBox.Show("Record Saved.", "School");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed.");
                    }

                }
                if (add_edit == false)
                {

                    //c.updatedata("tbl_class", c.myconn, this, "classno", txtclasscode.Text);

                    string uqry = "update tbl_class set classcode=@classcode,sectioncode=@sectioncode,sankaycode=@sankaycode,strength=@strength where classno=@classno";
                    SqlConnection conu = Connection.Conn();
                    SqlCommand cmdu = new SqlCommand(uqry, conu);
                    cmdu.Parameters.AddWithValue("@classcode", valcmbclass.SelectedValue.ToString().Trim());
                    cmdu.Parameters.AddWithValue("@sectioncode", valcmbsection.SelectedValue.ToString().Trim());
                    cmdu.Parameters.AddWithValue("@sankaycode", valcmbsankay.SelectedValue.ToString().Trim());
                    cmdu.Parameters.AddWithValue("@strength", textBox1.Text.Trim());
                    cmdu.Parameters.AddWithValue("@classno", txtclasscode.Text.Trim());
                    conu.Open();
                    cmdu.ExecuteNonQuery();
                    conu.Close();
                    MessageBox.Show("Record Updated.", "School");
                }

                c.FillListBox("select a.classno,b.classname+' '+c.sectionname   as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode order by a.classcode,c.sectioncode", "class", "classno", ref listBox1);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                

            }
            DesignForm.fromDesign1(this);
        }

        private void cmbclass_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //c.entertotab(e.KeyChar);

        }

        private void cmbsankay_Validating(object sender, CancelEventArgs e)
        {

            
        }

        private void cmbsankay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void valcmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_class", c.myconn, this, "classno", lstval);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
           
        }

        private void valcmbclass_Validated(object sender, EventArgs e)
        {

        }

        private void valcmbclass_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void valcmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //valcmbsankay.Items.Clear();
            DataSet ds = Connection.GetDataSet("Select classcode from tbl_classmaster where classname='" + valcmbclass.Text + "'");
            classno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            int classcode;
            if (Convert.ToInt32(classno) <= 110 || Convert.ToInt32(classno) > 112)
            {
               

              // valcmbsankay  .Items.Clear();
               c.FillcomboBox("select * from tbl_sankay where sankayname='Common' order by sankayname", "sankayname", "sankaycode", ref  valcmbsankay);   
               
            }
            else
            {
                //valcmbsankay.Items.Clear();
                c.FillcomboBox("select * from tbl_sankay where sankayname<>'Common' order by sankayname", "sankayname", "sankaycode", ref  valcmbsankay);   

            }
        }

       

        private void valcmbclass_Leave(object sender, EventArgs e)
        {
            valcmbsection .Focus();
        }
       
        private void textBox1_Validated(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(int.Parse(textBox1.Text));
            }
            catch
            {
                MessageBox.Show("Please Enter Numeric Value.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void frmclass_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);

        }

        


    }
}
