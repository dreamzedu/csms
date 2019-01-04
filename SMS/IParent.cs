using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS
{
    public interface IParent
    {
        bool IsNewCommandEnabled
        {
            get;
        }

        bool IsEditCommandEnabled
        {
            get;
        }

        bool IsSaveCommandEnabled
        {
            get;
        }

        bool IsPrintCommandEnabled
        {
            get;
        }

        bool IsDeleteCommandEnabled
        {
            get;
        }


        void DisableAllEditMenuButtons();

        void EnableAllEditMenuButtons();

        void ToggleNewButton(bool enable);

        void ToggleEditButton(bool enable);

        void ToggleDeleteButton(bool enable);

        void ToggleCancelButton(bool enable);

        void ToggleSaveButton(bool enable);

        void TogglePrintButton(bool enable);

        // These logic can be moved inside the button event call itself but that will need more effort to complete as it will impact all pages.
        void AfterNewClick();
        void AfterEditClick();

        void AfterSaveClick();

        void AfterCancelClick();

        void AfterDeleteClick();
    }
}
