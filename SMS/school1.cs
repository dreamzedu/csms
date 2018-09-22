using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System;
using CrystalDecisions.CrystalReports;
//using CrystalDecisions.Enterprise;
using System.Globalization;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using ListBox = System.Windows.Forms.ListBox;
using Panel = System.Windows.Forms.Panel;
using TextBox = System.Windows.Forms.TextBox;

namespace SMS
{

    public class school1
    {
        public string[] mnuitems;
        public SqlConnection myconn;
        public SqlDataAdapter sqlada;
        //public SqlTransaction trn  =new SqlTransaction ;
        public bool ADDPERM = false;
        public bool MODIPERM = false;
        public bool DELPERM = false;
        public bool PRINTPERM = false;
        public bool addmode = false;
        public int compcode;
        public string formname = "";

        public DateTime pdate1;
        public DateTime pdate2;
        public int user_id;
        public System.DateTime msys_lock_dt;
        public SqlDataReader grst;
        public const string trialProdKey = "0000-0000-0000-0000";
        public static CSMSUser CurrentUser;


        public MDIParent1 GetMdiParent(Control ctrl)
        {
            return (MDIParent1)ctrl.FindForm();
        }

        public DateTime GetFromDate(int sessioncode)
        {
            DateTime fdt;
            fdt = Convert.ToDateTime(Connection.GetExecuteScalar("select s_from from tbl_session where sessioncode='" + sessioncode + "'"));
            return fdt;
        }
        public DateTime GetToDate(int sessioncode)
        {
            DateTime fdt;
            fdt = Convert.ToDateTime(Connection.GetExecuteScalar("select s_to from tbl_session where sessioncode='" + sessioncode + "'"));
            return fdt;
        }
        public void entertotab(char keychar)
        {
            if (keychar.Equals('\r'))
            {
                SendKeys.Send("{Tab}");
            }
        }

        public static int PUserLevel;
        public int UserLevelCode = PUserLevel;
        public static int CurrentSessionCode;//= Loginform.CurrentSessionCode;
        public static string CurrentSessionName;
        public int PSessionCode = CurrentSessionCode;
        public void SYSLOCK_DATE()
        {
            //returnconn(myconn)
            string mySql = "SELECT system_locking FROM COMPANY WHERE C_CODE=" + compcode + "";
            DataSet myrs = new DataSet();
            SqlDataAdapter adpd = new SqlDataAdapter(mySql, myconn);
            adpd.Fill(myrs);
            if (myrs.Tables[0].Rows.Count > 0)
            {

                msys_lock_dt = System.Convert.ToDateTime(System.DateTime.Parse(myrs.Tables[0].Rows[0].ItemArray[0].ToString()));
            }
        }

        public int CHECKNUM(KeyPressEventArgs e)
        {

            if (e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 8 || e.KeyChar == 45)
            {
                return e.KeyChar;
            }
            else
            {
                return 0;
            }
        }
        public void filldataset(bool isstoredprocedure, ref DataSet ds, string msql, SqlConnection mcon)
        {
            //returnconn(mcon)

            //DataSet ds1 = new DataSet();
            sqlada = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            command = new SqlCommand();
            if (isstoredprocedure)
            {
                command.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                command.CommandType = CommandType.Text;
            }
            command = new SqlCommand(msql, mcon);
            sqlada.SelectCommand = command;
            //'sqlada = New SqlDataAdapter(msql, mcon)
            sqlada.SelectCommand.CommandTimeout = 120;
            sqlada.Fill(ds);
        }       
        public SqlDataReader fillreader(ref SqlDataReader dr, string msql, SqlConnection mcon)
        {
            //if (mcon.State != ConnectionState.Open)
            //    mcon.Open();
            SqlCommand com = new SqlCommand(msql, mcon);
            SqlDataReader reader = com.ExecuteReader();
            return reader;
        }
        public int getvchno(string vchtype, ref DateTime dtp, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select max(isnull(vchno,0))+1 from tbl_voucher WHERE vchtype='" + vchtype + "' and vchdate='" + dtp.Date.ToString() + "'", con);
            cmd.CommandTimeout = 120;
            Int32 VchNo;
            if (cmd.ExecuteScalar() == System.DBNull.Value)
            {
                VchNo = 1001;
            }
            else
            {
                VchNo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return VchNo;
        }
        public string getvouchernumber(string vchtype, ref DateTime dtp, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select max(isnull(vchno,0))+1 from tbl_voucher WHERE vchtype='" + vchtype + "'and vchdate='" + dtp.Date.ToString() + "'", con);
            cmd.CommandTimeout = 120;
            Int32 VchNo;
            if (cmd.ExecuteScalar() == System.DBNull.Value)
            {
                VchNo = 1001;
            }
            else
            {
                VchNo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return (vchtype + dtp.Date.ToString("ddMMyyyy") + VchNo).ToString();         
        }

        public void insertdata(string tblname, SqlConnection mcon, UserControl frm)
        {
            insertdata(tblname, mcon, frm.Controls);
        }

        public void insertdata(string tblname, SqlConnection mcon, Form frm)
        {
            insertdata(tblname, mcon, frm.Controls);
        }

        private void insertdata(string tblname, SqlConnection mcon, Control.ControlCollection controlCollection)
        {
            try
            {
                returnconn(myconn);
                DataSet ds1 = new DataSet();
                sqlada = new SqlDataAdapter("select * from " + tblname, mcon);
                sqlada.Fill(ds1);
                SqlCommandBuilder cmb = new SqlCommandBuilder(sqlada);
                DataRow row;
                row = ds1.Tables[0].NewRow();
                foreach (Control cnt in controlCollection)
                {
                    if (cnt is Panel)
                    {
                        foreach (Control cntrl in cnt.Controls)
                        {
                            SetRowValues(row, cntrl);
                        }
                    }
                    else
                    {
                        SetRowValues(row, cnt);
                    }
                    
                }
                ds1.Tables[0].Rows.Add(row);
                sqlada.Update(ds1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
        }


        private void SetRowValues(DataRow row, Control cnt)
        {
            String mtag = "";
           
            if (cnt.Tag == null)
            {
            }
            else
            {
                if (cnt.Tag.ToString() != "")
                {
                    mtag = cnt.Tag.ToString();
                    if (cnt is TextBox)
                    {
                        if (cnt.Text != "")
                        {
                            row[mtag] = cnt.Text;
                        }
                    }
                    if (cnt is ComboBox)
                    {
                        ComboBox cmb1 = (ComboBox) cnt;
                        try
                        {
                            if (cmb1.Name.Substring(0, 3) == "val")
                            {
                                row[mtag] = cmb1.SelectedValue;
                            }
                            else
                            {
                                if (cmb1.Name.Substring(0, 3) == "str")
                                {
                                    row[mtag] = cmb1.Text;
                                }
                                else
                                {
                                    row[mtag] = cmb1.SelectedIndex;
                                }
                            }
                        }
                        catch
                        {
                            row[mtag] = cmb1.SelectedItem;
                        }
                    }
                    if (cnt is CheckBox)
                    {
                        CheckBox cmb2 = (CheckBox) cnt;
                        row[mtag] = cmb2.CheckState;
                    }
                    if (cnt is DateTimePicker)
                    {
                        DateTimePicker cmb3 = (DateTimePicker) cnt;
                        row[mtag] = cmb3.Value;
                    }
                }
            }
        }

        public void insertstudentdata(string tblname, SqlConnection mcon, UserControl frm)
        {
            returnconn(myconn);
            DataSet ds1 = new DataSet();
            sqlada = new SqlDataAdapter("select * from " + tblname, mcon);
            sqlada.Fill(ds1);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sqlada);
            DataRow row;
            row = ds1.Tables[0].NewRow();
            int i = 0;
            foreach (Control cnt1 in frm.Controls)
            {
                if (cnt1 is TabControl)
                {
                    TabControl PNL = (TabControl)cnt1;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control cnt in PNL.TabPages[i].Controls)
                        {
                            String mtag = string.Empty;
                            if (cnt is GroupBox)
                            {
                                GroupBox gbox = (GroupBox)cnt;
                                foreach (Control inc in gbox.Controls)
                                {
                                    mtag = "";
                                    if (inc.Tag == null)
                                    {
                                    }
                                    else
                                    {
                                        if (inc.Tag.ToString() != "")
                                        {
                                            mtag = inc.Tag.ToString();
                                            if (inc is ComboBox)
                                            {
                                                ComboBox cmb1 = (ComboBox)inc;
                                                try
                                                {
                                                    if (cmb1.Name.Substring(0, 3) == "val")
                                                    {
                                                        row[mtag] = cmb1.SelectedValue;
                                                    }
                                                    if (cmb1.Name.Substring(0, 3) == "str")
                                                    {
                                                        row[mtag] = cmb1.Text;
                                                    }
                                                }
                                                catch (Exception ex) { Logger.LogError(ex); }
                                            }
                                            if (inc is CheckBox)
                                            {
                                                try
                                                {
                                                    CheckBox cmb2 = (CheckBox)inc;
                                                    //if (Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]) == 0)
                                                    //By GAtul.......
                                                    row[mtag] = cmb2.Checked;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.LogError(ex); 
                                                }
                                            }
                                            if (inc is TextBox)
                                            {
                                                try
                                                {
                                                    row[mtag] = inc.Text;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.LogError(ex); 
                                                }
                                            }
                                            if (inc is DateTimePicker)
                                            {
                                                DateTimePicker cmb3 = (DateTimePicker)inc;
                                                row[mtag] = cmb3.Value;
                                            }
                                        }
                                    }

                                }

                            }
                            else
                            {
                                mtag = "";
                                if (cnt.Tag == null)
                                {
                                }
                                else
                                {
                                    if (cnt.Tag.ToString() != "")
                                    {
                                        mtag = cnt.Tag.ToString();
                                        //MessageBox.Show(cnt.Name + "..." + cnt.Tag);

                                        if (cnt is TextBox)
                                        {
                                            if (cnt.Text != "")
                                            {
                                                try
                                                {
                                                    row[mtag] = cnt.Text;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.LogError(ex); MessageBox.Show(ex.Message);
                                                }
                                            }
                                        }

                                        if (cnt is ComboBox)
                                        {
                                            ComboBox cmb1 = (ComboBox)cnt;
                                            
                                            try
                                            {
                                                if (cmb1.Name.Substring(0, 3) == "val")
                                                {
                                                    row[mtag] = cmb1.SelectedValue;
                                                }
                                                else
                                                {
                                                    if (cmb1.Name.Substring(0, 3) == "str")
                                                    {
                                                        row[mtag] = cmb1.Text;
                                                    }
                                                    else
                                                    {
                                                        row[mtag] = cmb1.SelectedIndex;
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                row[mtag] = cmb1.SelectedItem;
                                            }
                                        }
                                        if (cnt is CheckBox)
                                        {
                                            CheckBox cmb2 = (CheckBox)cnt;
                                            //row[mtag] = cmb2.CheckState; 
                                            //By GAtul
                                            row[mtag] = cmb2.Checked;
                                        }
                                        if (cnt is DateTimePicker)
                                        {
                                            DateTimePicker cmb3 = (DateTimePicker)cnt;
                                            row[mtag] = cmb3.Value;
                                        }
                                    }
                                }
                            }
                        }
                        i++;

                    }

                    // }
                    // while (i < PNL.TabPages.Count);
                }
            }
            ds1.Tables[0].Rows.Add(row);
            sqlada.Update(ds1);
        }


        public void showdata(string tblname, SqlConnection mcon, UserControl frm, string fldname, string mvalue)
        {
            showdata(tblname, mcon, frm.Controls, fldname, mvalue);
        }


        public void showdata(string tblname, SqlConnection mcon, Form frm, string fldname, string mvalue)
        {
            showdata(tblname, mcon, frm.Controls, fldname, mvalue); 
        }


        public void showdata(string tblname, SqlConnection mcon, Control.ControlCollection controlCollection, string fldname,string mvalue)        
        {
            returnconn(myconn);
            DataSet ds1 = new DataSet();
            sqlada = new SqlDataAdapter("select * from " + tblname+" where " +fldname+" = '"+mvalue +"'", mcon);
            sqlada.Fill(ds1);
            if (ds1.Tables[0].Rows.Count == 0) 
            {
                ds1.Clear();
                return;
            }
            foreach (Control cnt in controlCollection)
            {
                if (cnt is Panel)
                {
                    foreach (Control cntrl in cnt.Controls)
                    {
                        SetControlValues(cntrl, ds1);
                    }
                }
                else
                {
                    SetControlValues(cnt, ds1);
                }
            }


        }

        private void SetControlValues(Control cnt, DataSet ds1)
        {
            String mtag = "";
            if (cnt.Tag != null && cnt.Tag.ToString() != "")
            {
                mtag = cnt.Tag.ToString();
                if (cnt is TextBox)
                {
                    cnt.Text = Convert.ToString(ds1.Tables[0].Rows[0][mtag]);
                }
                if (cnt is ComboBox)
                {
                    ComboBox cmb1 = (ComboBox)cnt;

                    if (cmb1.Name.Substring(0, 3) == "val")
                    {
                        cmb1.SelectedValue = ds1.Tables[0].Rows[0][mtag];
                    }
                    else
                    {
                        if (cmb1.Name.Substring(0, 3) == "str")
                        {
                            cmb1.Text = Convert.ToString(ds1.Tables[0].Rows[0][mtag]);
                        }
                        else
                        {
                            cmb1.SelectedIndex = Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]);
                        }
                    }
                    cmb1.Refresh();
                }
                if (cnt is CheckBox)
                {
                    try
                    {
                        CheckBox cmb2 = (CheckBox)cnt;
                        if (Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]) == 0)
                        {
                            cmb2.Checked = false;
                        }
                        else
                        {
                            cmb2.Checked = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex); 
                    }
                }
                if (cnt is DateTimePicker)
                {
                    DateTimePicker cmb3 = (DateTimePicker)cnt;
                    cmb3.Value = Convert.ToDateTime(ds1.Tables[0].Rows[0][mtag]);
                }
            }
        fline:
            Console.Write(""); 
        }

        public DataSet GetDataSet(string str)
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(str, myconn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public void showstudentdata(string tblname, SqlConnection mcon, UserControl frm, string fldname, string mvalue)
        {
            if (mvalue != "")
            {
                returnconn(myconn);
                DataSet ds1 = new DataSet();
                string str5 = "select * from " + tblname + " where " + fldname + " = '" + mvalue + "'";
                //DataSet ds5 = Connection.GetDataSet(str5);

                sqlada = new SqlDataAdapter(str5, mcon);
                sqlada.Fill(ds1);
                //SqlCommandBuilder cmb = new SqlCommandBuilder(sqlada);
                //DataRow row;
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    ds1.Clear();
                    //MessageBox.Show("Student Not Found..");
                    goto lastline;
                }
                //string acno = ds1.Tables[0].Rows[0]["ACNo"].ToString();
                //if (acno.Trim() != string.Empty)
                //{
                //    foreach (Control cnt1 in frm.Controls)
                //    {
                //        if (cnt1 is TabControl)
                //        {
                //            TabControl PNL = (TabControl)cnt1;
                //            foreach (TabPage tpg in PNL.TabPages)
                //            {
                //                foreach (Control cnt in PNL.TabPages[1].Controls)
                //                {
                //                    if (cnt is GroupBox)
                //                    {
                //                        GroupBox gbox = (GroupBox)cnt;
                //                        gbox.Visible = true;
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}


                int i = 0;
                foreach (Control cnt1 in frm.Controls)
                {
                    if (cnt1 is TabControl)
                    {
                        TabControl PNL = (TabControl)cnt1;
                        foreach (TabPage tpg in PNL.TabPages)
                        {
                            foreach (Control cnt in PNL.TabPages[i].Controls)
                            {
                                String mtag = string.Empty;

                                if (cnt is GroupBox)
                                {
                                    GroupBox gbox = (GroupBox)cnt;
                                    foreach (Control inc in gbox.Controls)
                                    {
                                        mtag = "";
                                        if (inc.Tag == null)
                                        {
                                            
                                        }
                                        else
                                        {
                                            if (inc.Tag.ToString() != "")
                                            {
                                                mtag = inc.Tag.ToString();
                                                if (inc is ComboBox)
                                                {
                                                    ComboBox cmb1 = (ComboBox)inc;
                                                    try
                                                    {
                                                        if (cmb1.Name.Substring(0, 3) == "val")
                                                        {
                                                            cmb1.SelectedValue = ds1.Tables[0].Rows[0][mtag];
                                                        }
                                                        if (cmb1.Name.Substring(0, 3) == "str")
                                                        {
                                                            cmb1.Text = ds1.Tables[0].Rows[0][mtag].ToString();
                                                        }
                                                    }
                                                    catch (Exception ex) { Logger.LogError(ex); }
                                                }
                                                if (inc is CheckBox)
                                                {
                                                    try
                                                    {
                                                        CheckBox cmb2 = (CheckBox)inc;
                                                        //if (Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]) == 0)
                                                        //By GAtul.......
                                                        if (Convert.ToBoolean(ds1.Tables[0].Rows[0][mtag]).Equals(true))
                                                        {
                                                            cmb2.Checked = true;
                                                        }
                                                        else
                                                        {
                                                            cmb2.Checked = false;
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Logger.LogError(ex); 
                                                    }
                                                }
                                                if (inc is TextBox)
                                                {
                                                    try
                                                    {
                                                        inc.Text = Convert.ToString(ds1.Tables[0].Rows[0][mtag]);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Logger.LogError(ex); 
                                                    }
                                                }
                                                if (inc is DateTimePicker)
                                                {
                                                    DateTimePicker cmb3 = (DateTimePicker)inc;
                                                    try
                                                    {
                                                        cmb3.Value = Convert.ToDateTime(ds1.Tables[0].Rows[0][mtag]);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Logger.LogError(ex); 
                                                    }
                                                }
                                            }
                                        }

                                    }

                                }
                                else
                                {
                                    mtag = "";
                                    if (cnt.Tag == null)
                                    {
                                        goto fline;
                                    }
                                    if (cnt.Tag.ToString() != "")
                                    {
                                        mtag = cnt.Tag.ToString();
                                        if (cnt is TextBox)
                                        {
                                            try
                                            {
                                                cnt.Text = Convert.ToString(ds1.Tables[0].Rows[0][mtag]);
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogError(ex); 
                                            }
                                        }
                                        if (cnt is ComboBox)
                                        {
                                            ComboBox cmb1 = (ComboBox)cnt;
                                            try
                                            {
                                                if (cmb1.Name.Substring(0, 3) == "val")
                                                {
                                                    cmb1.SelectedValue = ds1.Tables[0].Rows[0][mtag];
                                                }
                                                else if (cmb1.Name.Substring(0, 3) == "str")
                                                {
                                                    cmb1.Text = ds1.Tables[0].Rows[0][mtag].ToString();
                                                }
                                                else if (cmb1.Name.Substring(0, 3) == "str")
                                                {
                                                    cmb1.Text = ds1.Tables[0].Rows[0][mtag].ToString();
                                                }
                                                else
                                                {
                                                    if (cmb1.Name == "cmbdrcr")
                                                    {
                                                        cmb1.Text = Convert.ToString(ds1.Tables[0].Rows[0][mtag]);
                                                    }
                                                    else
                                                    {
                                                        cmb1.SelectedIndex = Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]);
                                                    }
                                                }
                                                cmb1.Refresh();
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogError(ex); 
                                            }
                                        }
                                        if (cnt is CheckBox)
                                        {
                                            try
                                            {
                                                CheckBox cmb2 = (CheckBox)cnt;
                                                //if (Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]) == 0)
                                                //By GAtul.......
                                                if (Convert.ToBoolean(ds1.Tables[0].Rows[0][mtag]).Equals(true))
                                                {
                                                    cmb2.Checked = true;
                                                }
                                                else
                                                {
                                                    cmb2.Checked = false;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogError(ex); 
                                            }
                                        }
                                        if (cnt is DateTimePicker)
                                        {
                                            DateTimePicker cmb3 = (DateTimePicker)cnt;
                                            try
                                            {
                                                cmb3.Value = Convert.ToDateTime(ds1.Tables[0].Rows[0][mtag]);
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogError(ex); 
                                            }
                                        }
                                    }
                                }
                            fline:
                                Console.Write("");
                            }
                            i++;
                        }
                    }
                }

            lastline:
                Console.Write("");
            }

        }


        public void updatedata(string tblname, SqlConnection mcon, UserControl frm, string fldname, string mvalue)
        {
            updatedata(tblname, mcon, frm.Controls, fldname, mvalue);
        }

        public void updatedata(string tblname, SqlConnection mcon, Form frm, string fldname, string mvalue)
        {
            updatedata(tblname, mcon, frm.Controls, fldname, mvalue);
        }
       
        private void updatedata(string tblname, SqlConnection mcon, Control.ControlCollection controlCollection, string fldname, string mvalue)
        {
            DataSet ds1 = new DataSet();
            sqlada = new SqlDataAdapter("select * from " + tblname + " where " + fldname + " = '" + mvalue +"'", mcon);
            sqlada.Fill(ds1);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sqlada);
            DataRow row;
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds1.Clear();
                goto lastline;
            }
            ds1.Tables[0].Rows[0].BeginEdit();
            foreach (Control cntrl in controlCollection)
            {
                if (cntrl is Panel)
                {
                    foreach (Control cnt in cntrl.Controls)
                    {
                        String mtag = "";
                        if (cnt.Tag == null)
                        {
                            continue;
                        }
                        if (cnt.Tag.ToString() != "")
                        {
                            mtag = cnt.Tag.ToString();
                            if (cnt is TextBox)
                            {
                                try
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cnt.Text;
                                }
                                catch (Exception ex)
                                {
                                    Logger.LogError(ex);
                                    //ds1.Tables[0].Rows[0][mtag] = 0;
                                }
                            }
                            if (cnt is ComboBox)
                            {
                                ComboBox cmb1 = (ComboBox)cnt;
                                if (cmb1.Name.Substring(0, 3) == "val")
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedValue;
                                }
                                else
                                {
                                    if (cmb1.Name.Substring(0, 3) == "str")
                                    {
                                        ds1.Tables[0].Rows[0][mtag] = cmb1.Text;
                                    }
                                    else
                                    {
                                        ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedIndex;
                                    }
                                }

                            }
                            if (cnt is CheckBox)
                            {
                                CheckBox cmb2 = (CheckBox)cnt;
                                ds1.Tables[0].Rows[0][mtag] = cmb2.CheckState;
                            }
                            if (cnt is DateTimePicker)
                            {
                                DateTimePicker cmb3 = (DateTimePicker)cnt;
                                if (cmb3.Name == "cmbdrcr")
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cmb3.Text;
                                }
                                else
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cmb3.Value;
                                }
                            }
                        }
                    }
                }
                else
                {
                    String mtag = "";
                    if (cntrl.Tag == null)
                    {
                        goto fline;
                    }
                    if (cntrl.Tag.ToString() != "")
                    {
                        mtag = cntrl.Tag.ToString();
                        if (cntrl is TextBox)
                        {
                            try
                            {
                                ds1.Tables[0].Rows[0][mtag] = cntrl.Text;
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError(ex);
                                //ds1.Tables[0].Rows[0][mtag] = 0;
                            }
                        }
                        if (cntrl is ComboBox)
                        {
                            ComboBox cmb1 = (ComboBox)cntrl;
                            if (cmb1.Name.Substring(0, 3) == "val")
                            {
                                ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedValue;
                            }
                            else
                            {
                                if (cmb1.Name.Substring(0, 3) == "str")
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cmb1.Text;
                                }
                                else
                                {
                                    ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedIndex;
                                }
                            }

                        }
                        if (cntrl is CheckBox)
                        {
                            CheckBox cmb2 = (CheckBox)cntrl;
                            ds1.Tables[0].Rows[0][mtag] = cmb2.CheckState;
                        }
                        if (cntrl is DateTimePicker)
                        {
                            DateTimePicker cmb3 = (DateTimePicker)cntrl;
                            if (cmb3.Name == "cmbdrcr")
                            {
                                ds1.Tables[0].Rows[0][mtag] = cmb3.Text;
                            }
                            else
                            {
                                ds1.Tables[0].Rows[0][mtag] = cmb3.Value;
                            }
                        }
                    }
                }
                
            fline:
                Console.Write("");
            }

            ds1.Tables[0].Rows[0].EndEdit(); 
            //ds1.Tables[0].AcceptChanges(); 
        sqlada.Update(ds1);
        lastline:
            Console.Write("");

        }

        public static string ToTitleCase(string mText)
        {
            string rText = "";
            try
            {
                System.Globalization.CultureInfo cultureInfo =
                System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
                rText = TextInfo.ToTitleCase(mText);
            }
            catch
            {
                rText = mText;
            }
            return rText;

        }
        public void updatestudentdata(string tblname, SqlConnection mcon, UserControl frm, string fldname, string mvalue)
        {

            DataSet ds1 = new DataSet();
            sqlada = new SqlDataAdapter("select * from " + tblname + " where " + fldname + " = " + mvalue, mcon);
            sqlada.Fill(ds1);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sqlada);
            DataRow row;
            if (ds1.Tables[0].Rows.Count == 0)
            {
                ds1.Clear();
                goto lastline;
            }
            ds1.Tables[0].Rows[0].BeginEdit();
            int i = 0;
            foreach (Control cnt1 in frm.Controls)
            {
                if (cnt1 is TabControl)
                {
                    TabControl PNL = (TabControl)cnt1;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control cnt in PNL.TabPages[i].Controls)
                        {
                            String mtag = string.Empty;
                            if (cnt is GroupBox)
                            {
                                GroupBox gbox = (GroupBox)cnt;
                                foreach (Control inc in gbox.Controls)
                                {
                                    mtag = "";
                                    if (inc.Tag == null)
                                    {
                                    }
                                    else
                                    {
                                        if (inc.Tag.ToString() != "")
                                        {
                                            mtag = inc.Tag.ToString();
                                            if (inc is ComboBox)
                                            {
                                                ComboBox cmb1 = (ComboBox)inc;
                                                try
                                                {
                                                    if (cmb1.Name.Substring(0, 3) == "val")
                                                    {
                                                        ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedValue;
                                                    }
                                                    if (cmb1.Name.Substring(0, 3) == "str")
                                                    {
                                                        ds1.Tables[0].Rows[0][mtag] = cmb1.Text;
                                                    }
                                                }
                                                catch (Exception ex) { Logger.LogError(ex); }
                                            }
                                            if (inc is CheckBox)
                                            {
                                                try
                                                {
                                                    CheckBox cmb2 = (CheckBox)inc;
                                                    //if (Convert.ToInt32(ds1.Tables[0].Rows[0][mtag]) == 0)
                                                    //By GAtul.......
                                                    ds1.Tables[0].Rows[0][mtag] = cmb2.Checked;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.LogError(ex); 
                                                }
                                            }
                                            if (inc is TextBox)
                                            {
                                                try
                                                {
                                                    ds1.Tables[0].Rows[0][mtag] = inc.Text;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.LogError(ex); 
                                                }
                                            }
                                            if (inc is DateTimePicker)
                                            {
                                                DateTimePicker cmb3 = (DateTimePicker)inc;
                                                ds1.Tables[0].Rows[0][mtag] = cmb3.Value;
                                                
                                            }
                                        }
                                    }

                                }

                            }
                            else
                            {
                                mtag = "";
                                if (cnt.Tag == null)
                                {
                                    goto fline;
                                }
                                if (cnt.Tag.ToString() != "")
                                {
                                    mtag = cnt.Tag.ToString();
                                    if (cnt is TextBox)
                                    {
                                        try
                                        {
                                            ds1.Tables[0].Rows[0][mtag] = cnt.Text;
                                        }
                                        catch (Exception ex)
                                        {
                                            Logger.LogError(ex); 
                                            //ds1.Tables[0].Rows[0][mtag] = 0;
                                        }
                                    }
                                    if (cnt is ComboBox)
                                    {
                                        ComboBox cmb1 = (ComboBox)cnt;
                                        if (cmb1.Name.Substring(0, 3) == "val")
                                        {
                                            ds1.Tables[0].Rows[0][mtag] = cmb1.SelectedValue;
                                        }
                                        else
                                        {
                                            ds1.Tables[0].Rows[0][mtag] = cmb1.Text;
                                        }
                                    }
                                    if (cnt is CheckBox)
                                    {
                                        CheckBox cmb2 = (CheckBox)cnt;
                                        //ds1.Tables[0].Rows[0][mtag] = cmb2.CheckState;
                                        //By GAtul
                                        ds1.Tables[0].Rows[0][mtag] = cmb2.Checked;
                                    }
                                    if (cnt is DateTimePicker)
                                    {
                                        DateTimePicker cmb3 = (DateTimePicker)cnt;
                                        if (cmb3.Name == "cmbdrcr")
                                        {
                                            ds1.Tables[0].Rows[0][mtag] = cmb3.Text;
                                        }
                                        else
                                        {
                                            ds1.Tables[0].Rows[0][mtag] = cmb3.Value;
                                        }
                                    }
                                }
                            }
                        fline:
                            Console.Write("");
                        }
                        i++;
                    }
                }
            }

            ds1.Tables[0].Rows[0].EndEdit();
            //ds1.Tables[0].AcceptChanges(); 
            sqlada.Update(ds1);
        lastline:
            Console.Write("");

        }

        public void changeinconfig(string constr)
        {
            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //// ConnectionStringsSection mySection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //config.ConnectionStrings.ConnectionStrings["SMS.Properties.Settings.SMSConnectionString"].ConnectionString = constr;
            //config.Save(ConfigurationSaveMode.Modified);  
        }

        public void getconnstr()
        {           
            string linein="";
            string conStr = linein; 
            conStr = Connection.GetConnectionString();
                myconn = new SqlConnection(conStr);
                myconn.Open(); 
           
            PSessionCode = 101;
            SqlCommand com = new SqlCommand("select * from tbl_session where sessioncode="+PSessionCode  , myconn);
            SqlDataReader reader = com.ExecuteReader();
             if (reader.HasRows)
            {
                reader.Read(); 
                pdate1 = Convert.ToDateTime(reader["s_from"]);
                pdate2 = Convert.ToDateTime(reader["s_to"]);
            }
             reader.Close();
        }
        public void FillCheckListBox(String strsql, String Displayfld, String Valuefld, ref  CheckedListBox  listBoxCust)
         {

            SqlDataAdapter sqlDA = new SqlDataAdapter(strsql, myconn);
            DataSet DS = new DataSet("DS");
            try
            {
                DS.Clear();
                DS.CaseSensitive = true;
                sqlDA.Fill(DS, "Cust");

                // fill listbox
                listBoxCust.DisplayMember = Displayfld;
                listBoxCust.ValueMember = Valuefld;
                listBoxCust.DataSource = DS.Tables[0];

            }
            catch (Exception MsgException)
            {
                Logger.LogError(MsgException); 
                MessageBox.Show(MsgException.Message);
            }

        }
    
        
        
        public void FillListBox(String strsql, String Displayfld, String Valuefld,ref  ListBox listBoxCust)
        {
            
            SqlDataAdapter  sqlDA = new SqlDataAdapter(strsql, myconn);
            DataSet  DS = new DataSet("DS");
            try
            {
                DS.Clear();
                DS.CaseSensitive = true;
                sqlDA.Fill(DS, "Cust");

                // fill listbox
                listBoxCust.DisplayMember = Displayfld ;
                listBoxCust.ValueMember = Valuefld ;
                listBoxCust.DataSource = DS.Tables[0];
                
            }
            catch (Exception MsgException)
            {
                Logger.LogError(MsgException); 
                MessageBox.Show(MsgException.Message) ;
            }

        }


        public void FillListBox(String cmd, SqlConnection con, String Displayfld, String Valuefld, ref  ListBox listBoxCust)
        {

            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd, con);
            DataSet DS = new DataSet("DS");
            try
            {
                DS.Clear();
                DS.CaseSensitive = true;
                sqlDA.Fill(DS, "Cust");
                con.Close();

                // fill listbox
                listBoxCust.DisplayMember = Displayfld;
                listBoxCust.ValueMember = Valuefld;
                
                listBoxCust.DataSource = DS.Tables[0];

            }
            catch (Exception MsgException)
            {
                Logger.LogError(MsgException); 
                MessageBox.Show(MsgException.Message);
            }

        }


        public void FillcomboBox(String strsql, String Displayfld, String Valuefld, ref  ComboBox  listBoxCust)
        {

            SqlDataAdapter sqlDA = new SqlDataAdapter(strsql, myconn);
            DataSet DS = new DataSet("DS");
            try
            {
                DS.Clear();
                DS.CaseSensitive = true;
                sqlDA.Fill(DS); //, "Cust");

                // fill listbox
                listBoxCust.DisplayMember = Displayfld;
                listBoxCust.ValueMember = Valuefld;
                listBoxCust.DataSource = DS.Tables[0];

            }
            catch (Exception MsgException)
            {
                Logger.LogError(MsgException); 
                MessageBox.Show(MsgException.Message);
            }

        }

        public void FillcomboBox(String cmd, SqlConnection con, String Displayfld, String Valuefld, ref  ComboBox listBoxCust)
        {

            SqlDataAdapter sqlDA = new SqlDataAdapter(cmd, con);
            DataSet DS = new DataSet("DS");
            try
            {
                DS.Clear();
                DS.CaseSensitive = true;
                sqlDA.Fill(DS); //, "Cust");

                con.Close();
                // fill listbox
                listBoxCust.DisplayMember = Displayfld;
                listBoxCust.ValueMember = Valuefld;
                listBoxCust.DataSource = DS.Tables[0];

            }
            catch (Exception MsgException)
            {
                Logger.LogError(MsgException); 
                MessageBox.Show(MsgException.Message);
            }

        }


        public void incBar()
        {
            //if (getmain.ProgressBar1.Value < getmain.ProgressBar1.Maximum)
            // {
            //     getmain.ProgressBar1.Value = getmain.ProgressBar1.Value + 1;
            // }
            //  else
            //  {
            //      getmain.ProgressBar1.Value = 1;
            // }
        }

        public char  CHECKDECIMAL(KeyPressEventArgs e)
        {
            if ((e.KeyChar > 44  &&  e.KeyChar <  58 ) ||  e.KeyChar == 8)
            {
                return e.KeyChar;
            }
            else
            {
                return ' ' ;
            }
        }

        public void executesql(string msql, SqlConnection cnn)
        {
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = msql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void connectsql(string msql, SqlConnection cnn, SqlTransaction sqltrn)
        {
            SqlCommand cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.Transaction = sqltrn;
            cmd.CommandTimeout = 250;
            cmd.CommandText = msql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void GetUserLevel()
        {
            string line1 = "";
            string str = "";
            str = Connection.GetConnectionString(); ;
            myconn = new SqlConnection(str);
            myconn.Open();
            // PUserLevel = "Chief";
            //PUserLevel =1;
            SqlCommand cmd = new SqlCommand("select UserLevel,UserCode from MasterUser where UserCode='" + PUserLevel + "'", Connection.GetUserDbConnection());
            SqlDataReader da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                da.Read();
            }
            da.Close();
            //myconn.Close();

        }
        public void returnconn(SqlConnection conn)
        {
            string linein = "";
            string conStr = "";
                conStr = Connection .GetConnectionString ();
                string mstr = conStr;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = mstr;
                    conn.Open();
                }
                else
                {

                    conn.Close();
                    conn.Dispose();
                    conn.ConnectionString = mstr;
                    conn.Open();

                } 
        }

      

        public void fillreaderwithsp(string param1, string param2, string param3, string param4, SqlDataReader  dr, string spname)
        {
            SqlCommand Command = new SqlCommand();
            //Command = Nothing;
            Command.CommandType = CommandType.StoredProcedure;
            Command = new SqlCommand(spname, myconn);
            if (param1 != "")
            {
                Command.Parameters.Add(param1);
            }
            if (param2 != "")
            {
                Command.Parameters.Add(param2);
            }
            if (param3 != "")
            {
                Command.Parameters.Add(param3);
            }
            if (param4 != "")
            {
                Command.Parameters.Add(param4);
            }
            Command.CommandTimeout = 120;
            dr = Command.ExecuteReader(); 
        }

       
        public void btnenable(Button btnnew ,Button  btnedit,Button  btndelete,Button btnsave,Button btncancel,Button btnprint,Button btnexit)
        {
            btnnew.Enabled = true;
           btnedit.Enabled = true;
            btndelete.Enabled =true;
           btnsave.Enabled = false;
            btncancel.Enabled = false;
            if (btnprint != null)
            {
                btnprint.Enabled = true;
            }
            if (btnexit != null)
            {
                btnexit.Enabled = true;
            }
        }
        public void btndisable(Button btnnew, Button btnedit, Button btndelete, Button btnsave, Button btncancel, Button btnprint, Button btnexit)
        {
            btnnew.Enabled = false;
           btnedit.Enabled = false;
            btndelete.Enabled = false;
           btnsave.Enabled = true;
            btncancel.Enabled = true;
            if (btnprint != null)
                btnprint.Enabled = true;
            if (btnexit != null)
            {
                btnexit.Enabled = true;
            }
        }

        public static string toproper(string mText)
        {
            string rText = "";
            try
            {
                System.Globalization.CultureInfo cultureInfo =
    System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
                rText = TextInfo.ToTitleCase(mText);
            }
            catch
            {
                rText = mText;
            }
            return rText;
        }  

        public void cleartext(Form frm)
        {
            cleartext(frm.Controls);
        }

        public void cleartext(UserControl frm)
        {
            cleartext(frm.Controls);
        }

        private void cleartext(Control.ControlCollection controlCollection)
        {
            foreach (Control cnt in controlCollection)
            {
                if (cnt is TextBox)
                {
                    cnt.Text = string.Empty;
                }
                if (cnt is ComboBox)
                {
                    
                    ComboBox cmb = (ComboBox)cnt;
                    if (cmb.Items.Count > 0)
                    {
                        cmb.SelectedIndex = 0;
                    }
                }
                if (cnt is CheckBox )
                {
                    
                    CheckBox  cmb = (CheckBox)cnt;
                    cmb.Checked  = false;
                }
                if (cnt is DateTimePicker)
                {

                    DateTimePicker cmb = (DateTimePicker)cnt;
                    cmb.Value = DateTime.Now;
                }
            }
            
        }


        internal void showdata(string p)
        {
            throw new NotImplementedException();
        }

         public static ErrorProvider ep = new ErrorProvider();

        public static bool ValidateDate(Control ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl.Text))
            {
                string[] formats = { "d/M/yyyy", "d/M/yy", "dd/MM/yyyy", "dd/MM/yy" };
                DateTime value;

                if (!DateTime.TryParseExact(ctrl.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out value))
                {
                    return false;
                }
            }
            return true;
            // ep.Clear();//write any where
        }
        //public static bool ValidateDate(TextBox t, CancelEventArgs e)
        //{


        //    //if (Connection .ValidateDate(t))
        //    //{
        //    //    ep.SetError(t, "");
        //    //    ep.Clear();//write any where
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    //MessageBox.Show("Invalid Date");
        //    //    //t.Focus();
        //    //    ep.SetError(t, "* Invalid Date");
        //    //    e.Cancel = true;
        //    //    return false;
        //    //}
        //}

        public static void CheckEmptyString(TextBox t, CancelEventArgs e)
        {
            // <summary>Validate to make sure that the textbox contains a string with at least one character</summary>
            // <param name="sender"></param><param name="e"></param>
            //calling the function from control like this
            //ControlValidation.CheckEmptyString(txtBillNo, e);
            bool bTest = txtEmptyStringIsValid(t);
            if (bTest == true)
            {
                ep.SetError(t, "This field must contain text");
                e.Cancel = true;// not skip without value
            }
            else
            {
                ep.SetError(t, "");
            }
        }
        public static bool txtEmptyStringIsValid(TextBox t)
        {
            // <summary>Test for empty string in the text box and return the results</summary>
            // <returns>boolean</returns> 
            if (t.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CheckMobileNumber(TextBox t, CancelEventArgs e)
        {
            // <summary>Test the contents of this text box against a regular expression</summary>
            // <param name="sender"></param><param name="e"></param>
            bool bTest = txtRegExStringIsValid(t.Text.ToString());
            if (bTest == false)
            {
                ep.SetError(t, "This field must contain a 10 Digit Mobile number");
                t.Focus();
                t.SelectAll();
            }
            else
            {
                ep.SetError(t, "");
            }
        }
        public static bool txtRegExStringIsValid(string textToValidate)
        {
            // <summary>Test for a regex expression match in the text box and return the results - the example uses a regular expression used to validate a phone number </summary>
            // <returns>boolean</returns>
            Regex TheRegExpression;
            string TheTextToValidate;
            string TheRegExTest = @"^[0-9]{10}$";//"^[0-9]{10}","\d{2}-\d{3}-\d{4}";
            TheTextToValidate = textToValidate;
            TheRegExpression = new Regex(TheRegExTest);
            // test text with expression
            if (TheRegExpression.IsMatch(TheTextToValidate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckNumericValueOnly(TextBox t, CancelEventArgs e)
        {
            // <summary>Validate that the textbox contains only numbers</summary>
            // <param name="sender"></param><param name="e"></param>
            bool bTest = txtNumericStringIsValid(t);
            if (bTest == true)
            {
                ep.SetError(t, "This field must contain only numbers");
                e.Cancel = true;
                t.SelectAll();
                return false;
            }
            else
            {
                ep.SetError(t, "");
                ep.Clear();
                return true;
            }
        }
        public static bool txtNumericStringIsValid(TextBox t)
        {
            // <summary>Test for non-numeric values in the text box and also make sure the textbox is not empty</summary>
            // <returns>boolean</returns> 
            if (t.Text == string.Empty)
            {
                return true;
            }
            char[] testArr = t.Text.ToCharArray();
            bool testBool = false;
            for (int i = 0; i < testArr.Length; i++)
            {
                if (!char.IsNumber(testArr[i]) && testArr[i] != '.')
                {
                    testBool = true;
                }
            }
            return testBool;
        }

        public static void CheckalphasOnly(TextBox t, CancelEventArgs e)
        {
            bool bTest = txtAlphaStringIsValid(t);
            if (bTest == true)
            {
                ep.SetError(t, "This field must contain only alphas");
                e.Cancel = true;
                t.SelectAll();
            }
            else
            {
                ep.SetError(t, "");
            }
        }
        public static bool txtAlphaStringIsValid(TextBox t)
        {
            // first make sure the textbox contains something
            if (t.Text == string.Empty)
            {
                return true;
            }
            // test each character in the textbox
            char[] testArr = t.Text.ToCharArray();
            bool testBool = false;
            for (int i = 0; i < testArr.Length; i++)
            {
                if (!char.IsLetter(testArr[i]))
                {
                    testBool = true;
                }
            }
            return testBool;
        }


        public static bool CheckNumericValueOnly1(TextBox t)
        {
            // <summary>Validate that the textbox contains only numbers</summary>
            // <param name="sender"></param><param name="e"></param>
            bool bTest = txtNumericStringIsValid(t);
            if (bTest == true)
            {
                ep.SetError(t, "This field must contain only numbers");
                // e.Cancel = true;
                t.SelectAll();
                return false;
            }
            else
            {
                ep.SetError(t, "");
                ep.Clear();
                return true;
            }
        }

        
        public static string ConvertToDateTime(string dateTimeString)
        {
            dateTimeString = dateTimeString.Replace("-", "/");
            string[] dates = dateTimeString.Split('/');
            dateTimeString = dates[1] + "/" + dates[0] + "/" + dates[2];
            return dateTimeString;
        } 

        internal static void CheckEmptyString(frmuser frmuser)
        {
            throw new NotImplementedException();
        }

        internal string ConstructProductKey(string schoolName, string city, string day, string month, string year)
        {
            var key = "";
            string s4 = schoolName.Substring(0, 4).ToUpper();
            string c3 = city.Substring(0, 3).ToUpper();
            string d2 = day.Length == 1 ? "0" + day : day;
            string m2 = month.Length == 1 ? "0" + month : month;
            string y4 = year;


            int index = 0;
            index = alfa.IndexOf(s4[0]);
            if (index > -1)
                key += alfa[index + 2];

            index = alfa.IndexOf(c3[0]);
            if (index > -1)
                key += alfa[index + 2];

            index = alfa.IndexOf(s4[1]);
            if (index > -1)
                key += alfa[index + 2];

            key += alfa[Convert.ToInt16(y4[1].ToString())];

            key += "-";

            key += alfa[Convert.ToInt16(y4[0].ToString())];

            index = alfa.IndexOf(c3[2]);
            if (index > -1)
                key += alfa[index + 2];

            key += alfa[Convert.ToInt16(y4[1].ToString())];

            key += alfa[Convert.ToInt16(d2[1].ToString())];

            key += "-";

            key += alfa[Convert.ToInt16(d2[0].ToString())];

            key += alfa[Convert.ToInt16(m2[0].ToString())];

            index = alfa.IndexOf(s4[3]);
            if (index > -1)
                key += alfa[index + 2];

            key += alfa[Convert.ToInt16(y4[2].ToString())];

            key += "-";

            key += alfa[Convert.ToInt16(m2[1].ToString())];

            index = alfa.IndexOf(s4[2]);
            if (index > -1)
                key += alfa[index + 2];

            index = alfa.IndexOf(c3[1]);
            if (index > -1)
                key += alfa[index + 2];

            return key;

        }

      
        private string alfa = "ABCDEFGHIJKLMNOPQRSTUVWXYZABC";

    }

}