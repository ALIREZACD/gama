using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace GAMA.Classes
{
    public class TextBoxRegexable
    {
        public TextBoxRegexable(string regexPattern, params TextBoxBase[] textBoxes)
        {
            _regexPattern = regexPattern;
            SetEvents(textBoxes);
        }


        #region Fields

        private readonly string _regexPattern = string.Empty;

        #endregion


        #region Event Implications

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBase textBox = sender as TextBoxBase;
            if (!IsTextOnPattern(textBox.Text + e.KeyChar))
                e.Handled = true;
        }

        #endregion


        #region Fucntions

        private void SetEvents(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
                controls[i].KeyPress += TextBox_KeyPress;
        }

        private bool IsTextOnPattern(string text)
        {
            bool result = Regex.IsMatch(text, _regexPattern);
            return result;
        }

        #endregion
    }
}
