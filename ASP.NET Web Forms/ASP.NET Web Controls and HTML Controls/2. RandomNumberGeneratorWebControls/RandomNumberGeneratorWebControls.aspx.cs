using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.RandomNumberGeneratorWebControls
{
    public partial class RandomNumberGeneratorWebControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Random generator = new Random();

            try
            {
                int minNumber = int.Parse(this.TextBoxMinNumber.Text);
                int maxNumber = int.Parse(this.TextBoxMaxNumber.Text);
                int result = generator.Next(minNumber, maxNumber + 1);
                this.Result.Text = result.ToString();
            }
            catch (Exception ex)
            {
                this.Result.Text = "Error!";
            }
        }
    }
}