using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _4.NorthwindEmployeesRepeater
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterEmployees.DataSource = new NorthwindEntities().Employees.ToList();
            Page.DataBind();
        }
    }
}