using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2a.SumNumbersWebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSumNumbers_Click(object sender, EventArgs e)
        {
            try
            {
                decimal first = decimal.Parse(this.TextBoxFirstNumber.Text);
                decimal second = decimal.Parse(this.TextBoxSecondNumber.Text);
                decimal result = SumNumbers(first, second);
                this.TextBoxResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                this.TextBoxResult.Text = "Error!";
            }
        }

        private decimal SumNumbers(decimal first, decimal second)
        {
            return first + second;
        }
    }
}