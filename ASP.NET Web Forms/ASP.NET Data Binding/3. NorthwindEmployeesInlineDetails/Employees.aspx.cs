using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _3.NorthwindEmployeesInlineDetails
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var employees = new NorthwindEntities().Employees.ToList();
            this.GridViewEmployees.DataSource = employees;
            if (Request.QueryString["id"] != null)
            {
                this.FormViewEmployeeDetails.DataSource = employees;
                int id = int.Parse(Request.QueryString["id"]) - 1;
                this.FormViewEmployeeDetails.PageIndex = id;
            }

            Page.DataBind();

        }
    }
}