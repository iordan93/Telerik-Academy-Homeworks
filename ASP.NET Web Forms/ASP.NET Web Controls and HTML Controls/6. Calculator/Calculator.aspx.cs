using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _6.Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private const string ErrorMessage = "Error!";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TextBoxDisplay.Text = string.Empty;
            this.FieldStorage.Value = "";
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            this.PerformOperation();
            this.Operator.Value = "+";
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            this.PerformOperation();
            this.Operator.Value = "-";
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e)
        {
            this.PerformOperation();
            this.Operator.Value = "*";
        }

        protected void ButtonDivide_Click(object sender, EventArgs e)
        {
            this.PerformOperation();
            this.Operator.Value = "/";
        }

        protected void ButtonSqrt_Click(object sender, EventArgs e)
        {
            this.Operator.Value = "sqrt";
            this.PerformOperation();
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            this.PerformOperation();
            this.Operator.Value = "";
        }

        protected void PressNumberButton(object sender, EventArgs e)
        {
            if (this.CheckBoxIsOperatorPressed.Checked)
            {
                this.TextBoxDisplay.Text = string.Empty;
                this.CheckBoxIsOperatorPressed.Checked = false;
            }

            this.TextBoxDisplay.Text += (sender as Button).Text;
        }

        private void PerformOperation()
        {
            decimal display = 0;
            decimal storage = 0;

            if (this.TextBoxDisplay.Text != string.Empty && this.TextBoxDisplay.Text != ErrorMessage)
            {
                display = decimal.Parse(this.TextBoxDisplay.Text);
            }

            if (this.FieldStorage.Value != string.Empty)
            {
                storage = decimal.Parse(this.FieldStorage.Value);
            }

            try
            {
                decimal result = GetResult(display, storage);
                this.FieldStorage.Value = result.ToString();
                this.TextBoxDisplay.Text = Math.Round(result, 14).ToString();
            }
            catch (Exception)
            {
                this.TextBoxDisplay.Text = ErrorMessage;
                this.FieldStorage.Value = string.Empty;
            }

            this.CheckBoxIsOperatorPressed.Checked = true;
        }

        private decimal GetResult(decimal display, decimal storage)
        {
            switch (this.Operator.Value)
            {
                case "":
                    return display;
                case "+":
                    return storage + display;
                case "-":
                    return storage - display;
                case "*":
                    return storage * display;
                case "/":
                    return storage / display;
                case "sqrt":
                    return (decimal)Math.Sqrt((double)display);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}