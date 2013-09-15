using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.NorthwindEmployees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            using (var context = new NorthwindEntities())
            {
                var employee = context.Employees.Where(emp => emp.EmployeeID == id).ToList();
                this.DetailsViewEmployee.DataSource = employee;
            }

            Page.DataBind();
        }
        
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employees.aspx");
        }
    }
}