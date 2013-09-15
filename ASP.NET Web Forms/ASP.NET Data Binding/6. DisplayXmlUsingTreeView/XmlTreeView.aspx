<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlTreeView.aspx.cs" Inherits="_6.DisplayXmlUsingTreeView.XmlTreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML Tree View</title>
    <style type="text/css">
        .inner-text {
            position: absolute;
            top: 20px;            
            left: 250px;
        }
    </style>
</head>
<body>
    <form id="XMLTreeView" runat="server">

        <asp:XmlDataSource ID="XmlDataSourceBooks" runat="server" DataFile="books.xml" />
        <asp:TreeView ID="TreeViewXml" ImageSet="Arrows" runat="server" DataSourceID="XmlDataSourceBooks"
            OnTreeNodeDataBound="TreeViewXml_TreeNodeDataBound" OnSelectedNodeChanged="TreeViewBooks_SelectedNodeChanged">
        </asp:TreeView>
        <asp:Label ID="LabelInnerText" runat="server" CssClass="inner-text" />
    </form>
</body>
</html>
