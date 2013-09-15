using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _5.NorthwindEmployeesListView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewEmployees.DataSource = new NorthwindEntities().Employees.ToList();

            Page.DataBind();
        }
    }
}