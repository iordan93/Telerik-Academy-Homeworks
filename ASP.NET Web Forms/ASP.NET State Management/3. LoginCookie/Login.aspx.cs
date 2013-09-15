using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3.LoginCookie
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                Response.Redirect("~/LoginCookie.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookieUser = new HttpCookie("user");
            cookieUser.Values.Add("username", this.TextBoxUsername.Text);
            cookieUser.Values.Add("password", this.TextBoxPassword.Text);
            cookieUser.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookieUser);

            Response.Redirect("~/LoginCookie.aspx");
        }
    }
}