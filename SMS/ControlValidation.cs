using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SMS
{
    class ControlValidation
    {
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
        //    //if (Connection.ValidateDate(t))
        //    //{
        //    //    ep.SetError(t, "");
        //    //    ep.Clear();//write any where
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    //MessageBox.Show("Invalid Date");
        //    //    //t.Focus();
        //    //    ep.SetError(t, "* Invalid Date Please follow dd/MM/yyyy");
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
                //if (t.Text != ".")
                //{
                    if (!char.IsLetter(testArr[i]))
                    {
                        if (!char.IsWhiteSpace(testArr[i]))                          
                            testBool = true;
                    }
               // }
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

        //public void CheckDecimal_KeyPress(TextBox t, KeyPressEventArgs e)
        //{
        //    ////if ((e.KeyChar >= '0') || (e.KeyChar <= '9'))
        //    ////    e.Handled = true;

        //    if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
        //    & e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }

        //    base.OnKeyPress(e);

        //}
        //public static void Validate(KeyPressEventArgs E)
        //{
        //    if (!char.IsNumber(E.KeyChar) & (Keys)E.KeyChar != Keys.Back
        //    & E.KeyChar != '.')
        //    {
        //        E.Handled = true;              
        //    }
        //} 
        //private void txtPurchasePrice_KeyPress_1(object sender, KeyPressEventArgs e)
        //{
        //    ControlValidation.Validate(e);
        //}

        public static string ConvertToDateTime(string dateTimeString)
        {
            dateTimeString = dateTimeString.Replace("-", "/");
            string[] dates = dateTimeString.Split('/');
            dateTimeString = dates[1] + "/" + dates[0] + "/" + dates[2];
            return dateTimeString;
        }

        public static bool checkEmptyTextBox(TextBox t)
        {
            if (string.IsNullOrEmpty(t.Text))
            {
                //ep.SetError(t, "Must Enter");
                return false;

            }
            else
            {
                return true;
            }
        }
    }
}
