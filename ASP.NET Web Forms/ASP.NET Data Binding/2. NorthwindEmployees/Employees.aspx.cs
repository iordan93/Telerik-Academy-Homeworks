using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.NorthwindEmployees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                this.GridViewEmployees.DataSource = context.Employees.ToList();

                Page.DataBind();
            }
        }
    }
}