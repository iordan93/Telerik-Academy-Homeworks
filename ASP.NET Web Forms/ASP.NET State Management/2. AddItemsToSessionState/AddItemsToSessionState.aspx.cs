using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.AddItemsToSessionState
{
    public partial class AddItemsToSessionState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonAddToSessionState_Click(object sender, EventArgs e)
        {
            (Session["allItems"] as List<string>).Add(this.InputText.Text);

            this.PanelAddItemToSessionState.Visible = false;
            this.PanelShowSessionStateItem.Visible = true;
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.PanelAddItemToSessionState.Visible = true;
            this.PanelShowSessionStateItem.Visible = false;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (Session["allItems"] == null)
            {
                Session["allItems"] = new List<string>();
            }

            this.LabelSessionStateItem.Text = Server.HtmlEncode(string.Join(", ", (Session["allItems"] as List<string>)));
        }
    }
}