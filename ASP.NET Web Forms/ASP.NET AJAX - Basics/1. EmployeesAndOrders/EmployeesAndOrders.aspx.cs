using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1.EmployeesAndOrders
{
    public partial class EmployeesAndOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new NorthwindEntities();
                this.GridViewEmployees.DataSource = context.Employees.ToList();
                this.GridViewEmployees.DataBind();
                this.RebindOrders();
            }
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            this.RebindOrders();
        }

        protected void GridViewOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewOrders.PageIndex = e.NewPageIndex;
            this.RebindOrders();
        }

        private void RebindOrders()
        {
            int employeeId = Convert.ToInt32(this.GridViewEmployees.SelectedValue);
            var context = new NorthwindEntities();
            this.GridViewOrders.DataSource = context.Orders.Where(o => o.EmployeeID == employeeId).ToList();
            this.GridViewOrders.DataBind();
        }
    }
}