using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public class UserControlBase : UserControl
    {
        public virtual void btnnew_Click(object sender, EventArgs e)
        { }

        public virtual void btncancel_Click(object sender, EventArgs e)
        { }

        public virtual void btnedit_Click(object sender, EventArgs e)
        { }

        public virtual void btnsave_Click(object sender, EventArgs e)
        { }

        public virtual void btndelete_Click(object sender, EventArgs e) { }

        public virtual void btnprint_Click(object sender, EventArgs e) { }

        public virtual void frm_keydown(object sender, KeyEventArgs e)
        {
            MDIParent1 frm = (MDIParent1)sender;

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N && frm.IsNewCommandEnabled)
            {
                this.btnnew_Click(sender, new EventArgs());
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.E && frm.IsEditCommandEnabled)
            {
                this.btnedit_Click(sender, new EventArgs());
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                this.btnprint_Click(sender, new EventArgs());
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S && frm.IsSaveCommandEnabled)
            {
                this.btnsave_Click(sender, new EventArgs());
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
            {
                this.btndelete_Click(sender, new EventArgs());
            }
            

            base.OnKeyDown(e);
        }
    }
}
