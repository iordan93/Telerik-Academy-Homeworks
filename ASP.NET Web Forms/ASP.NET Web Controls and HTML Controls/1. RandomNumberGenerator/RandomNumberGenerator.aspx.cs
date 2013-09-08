using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.RandomNumberGenerator
{
    public partial class RandomNumberGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_ServerClick(object sender, EventArgs e)
        {
            Random generator = new Random();

            try
            {
                int minNumber = int.Parse(this.MinNumber.Value);
                int maxNumber = int.Parse(this.MaxNumber.Value);
                int result = generator.Next(minNumber, maxNumber + 1);
                this.Result.InnerText = result.ToString();
            }
            catch (Exception ex)
            {
                this.Result.InnerText = "Error!";
            }
        }
    }
}