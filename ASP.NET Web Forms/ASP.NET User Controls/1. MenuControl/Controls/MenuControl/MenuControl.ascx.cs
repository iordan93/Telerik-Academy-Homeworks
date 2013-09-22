using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models = _1.MenuControl.Models;

namespace _1.MenuControl.Controls.MenuControl
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        private MenuControl innerItems;

        public List<Models.MenuItem> DataSource { get; set; }

        public Color FontColor
        {
            get
            {
                return this.DataListMenuItems.ForeColor;
            }

            set
            {
                this.DataListMenuItems.ForeColor = value;
            }
        }

        public string FontName
        {
            get
            {
                return this.DataListMenuItems.Font.Name;
            }
            set
            {
                this.DataListMenuItems.Font.Name = value;
            }
        }

        public RepeatDirection RepeatDirection
        {
            get
            {
                return this.DataListMenuItems.RepeatDirection;
            }
            set
            {
                this.DataListMenuItems.RepeatDirection = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IncludeCss();
        }

        public override void DataBind()
        {
            this.DataListMenuItems.DataSource = this.DataSource;
            base.DataBind();
        }

        protected void DataListMenuItems_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                HyperLink hyperLinkItem = (HyperLink)e.Item.FindControl("HyperLinkItem");
                hyperLinkItem.ForeColor = this.FontColor;
                hyperLinkItem.Font.Name = this.FontName;
            }
        }

        private void IncludeCss()
        {
            ClientScriptManager cs = Page.ClientScript;

            string cssRelativeURL = this.TemplateSourceDirectory + "/Styles/MenuControl.css";
            if (!cs.IsClientScriptBlockRegistered(cssRelativeURL))
            {
                string cssLinkCode = string.Format(@"<link href='{0}' rel='stylesheet' type='text/css' />", cssRelativeURL);
                cs.RegisterClientScriptBlock(this.GetType(), cssRelativeURL, cssLinkCode);
            }
        }
    }
}