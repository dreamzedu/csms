using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class PlaceHolderForm : Form, IParent
    {
        public PlaceHolderForm(string title)
        {
            InitializeComponent();
            //this.lblTitle.Text = title;
            this.Text = title;
        }

        public void AddChildControl(Control ctrl)
        {
            this.Height = ctrl.Height;
            this.Width = ctrl.Width;
            ctrl.BackColor = this.BackColor;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.btnnew.Focus();
            this.pnlMain.Controls.Add(ctrl);
        }

        public bool IsNewCommandEnabled
        {
            get { return btnnew.Enabled; }
        }

        public bool IsEditCommandEnabled
        {
            get { return btnsave.Enabled; }
        }

        public bool IsSaveCommandEnabled
        {
            get { return btnsave.Enabled; }
        }

        public bool IsPrintCommandEnabled
        {
            get { return btnprint.Enabled; }
        }

        public bool IsDeleteCommandEnabled
        {
            get { return btndelete.Enabled; }
        }

        public void btnnew_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnnew_Click(sender, e);
        }

        public void btnedit_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnedit_Click(sender, e);
        }

        public void btndelete_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btndelete_Click(sender, e);
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnsave_Click(sender, e);
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btncancel_Click(sender, e);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnprint_Click(sender, e);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DisableAllEditMenuButtons()
        {
            this.btncancel.Enabled = true;
            this.btnedit.Enabled = false;
            this.btnsave.Enabled = true;
            this.btndelete.Enabled = false;
            this.btnprint.Enabled = true;
            this.btnnew.Enabled = false;
        }

        public void EnableAllEditMenuButtons()
        {
            this.btncancel.Enabled = false;
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btndelete.Enabled = true;
            this.btnprint.Enabled = true;
            this.btnnew.Enabled = true;
        }

        public void ToggleNewButton(bool enable)
        {
            this.btnnew.Enabled = enable;
        }

        public void ToggleEditButton(bool enable)
        {
            if (enable)
            {
                if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
                {
                    this.btnedit.Enabled = enable;
                }
            }
            else
            {
                this.btnedit.Enabled = enable;
            }
        }

        public void ToggleDeleteButton(bool enable)
        {
            if (enable)
            {
                if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
                {
                    this.btndelete.Enabled = enable;
                }
            }
            else
            {
                this.btndelete.Enabled = enable;
            }
        }

        public void ToggleCancelButton(bool enable)
        {
            this.btncancel.Enabled = enable;
        }

        public void ToggleSaveButton(bool enable)
        {
            this.btnsave.Enabled = enable;
        }

        public void TogglePrintButton(bool enable)
        {
            this.btnprint.Enabled = enable;
        }

        // These logic can be moved inside the button event call itself but that will need more effort to complete as it will impact all pages.
        public void AfterNewClick()
        {
            btncancel.Enabled = true;
            btnnew.Enabled = false;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            btnsave.Enabled = true;
        }

        public void AfterEditClick()
        {
            btncancel.Enabled = true;
            btnnew.Enabled = false;
            btnedit.Enabled = false;
            btnsave.Enabled = true;
        }

        public void AfterDeleteClick()
        {
            btncancel.Enabled = false;
            btnnew.Enabled = true;
            btnedit.Enabled = false;
            btnsave.Enabled = false;
            btndelete.Enabled = false;
        }

        public void AfterSaveClick()
        {
            btncancel.Enabled = false;
            btnnew.Enabled = true;
            if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
            {
                btnedit.Enabled = true;
            }
            btndelete.Enabled = false;
            btnsave.Enabled = false;
            btnnew.Focus();
        }

        public void AfterCancelClick()
        {
            btncancel.Enabled = false;
            btnnew.Enabled = true;
            if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
            {
                btnedit.Enabled = true;
            }
            btndelete.Enabled = false;
            btnsave.Enabled = false;
        }

        private void PlaceHolderForm_Load(object sender, EventArgs e)
        {
            //lblTitle.Location = new Point((this.Width - lblTitle.Width) / 2, 10);
        }

        private void PlaceHolderForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {                
                if (pnlMain.Controls.Count > 0)
                {
                    ((UserControlBase)pnlMain.Controls[0]).frm_keydown(sender, e);
                }

            }
            catch (Exception ex) { Logger.LogError(ex); }
        }

    }
}
