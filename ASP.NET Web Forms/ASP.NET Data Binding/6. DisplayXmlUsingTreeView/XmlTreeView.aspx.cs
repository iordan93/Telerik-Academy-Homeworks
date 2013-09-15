using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _6.DisplayXmlUsingTreeView
{
    public partial class XmlTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TreeViewBooks_SelectedNodeChanged(object sender, EventArgs e)
        {
            var selectedNode = this.TreeViewXml.SelectedNode;
            if (selectedNode.ChildNodes.Count == 0)
            {
                this.LabelInnerText.Text = selectedNode.Value;
            }
            else
            {
                selectedNode.ToggleExpandState();
            }
        }

        protected void TreeViewXml_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            e.Node.Value = (e.Node.DataItem as XmlElement).InnerText;
        }
    }
}