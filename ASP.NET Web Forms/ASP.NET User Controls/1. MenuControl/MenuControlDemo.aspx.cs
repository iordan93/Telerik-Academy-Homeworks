using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using _1.MenuControl.Models;

namespace _1.MenuControl
{
    public partial class MenuControlDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var items = new List<MenuItem>() 
            {
                new MenuItem()
                {
                    Text="Google",
                    Url="http://google.com"
                },
                new MenuItem()
                {
                    Text="Yahoo",
                    Url="http://yahoo.com"
                },
                new MenuItem()
                {
                    Text="Bing",
                    Url="http://bing.com"
                },
                new MenuItem()
                {
                    Text="YouTube",
                    Url="http://youtube.com"
                },
                new MenuItem()
                {
                    Text="Wikipedia",
                    Url="http://wikipedia.org"
                }
            };

            this.MenuControlMain.DataSource = items;
            this.DataBind();
        }
    }
}