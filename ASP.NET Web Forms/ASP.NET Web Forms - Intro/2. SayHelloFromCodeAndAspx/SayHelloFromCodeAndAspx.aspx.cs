using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.SayHelloFromCodeAndAspx
{
    public partial class SayHelloFromCodeAndAspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal literal = new Literal()
            {
                Text = "Hello from C# code!",
            };

            this.PlaceholderHello.Controls.Add(literal);

            this.TextBoxAssembly.Text = "Executing assembly: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}