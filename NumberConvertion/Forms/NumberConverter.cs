using System;
using System.Windows.Forms;
using NumberConverter.Model.NumberToWords.English;

namespace NumberConvertion
{
    public partial class number_converter : Form
    {
        public number_converter()
        {
            InitializeComponent();
            this.tb_input.Focus();
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            this.ClearLabel();

            try
            {
                EnglishUSDConverter number = new EnglishUSDConverter(this.tb_input.Text);
                this.lbl_ouput.Text = number.ConvertNumberIntoWords();
                //this.lbl_ouput.Text = number.MainValue + " # " + number.CentsValue;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.lbl_warning.Text = ex.Message;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.ClearMainTextBox();
            this.ClearLabel();
        }

        private void tb_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void ClearMainTextBox()
        {
            this.tb_input.Text = "0";
        }

        private void ClearLabel()
        {
            this.lbl_ouput.Text = "";
            this.lbl_warning.Text = "";
        }

        private void tb_input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Do something
                this.btn_convert_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
