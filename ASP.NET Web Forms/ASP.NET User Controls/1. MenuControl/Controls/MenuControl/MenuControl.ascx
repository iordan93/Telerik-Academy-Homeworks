<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="_1.MenuControl.Controls.MenuControl.MenuControl" %>

<script type="text/css" src="<%= ResolveUrl("Styles/MenuControl.css") %>"></script>
<link href="Styles/MenuControl.css" rel="stylesheet" />

<asp:DataList ID="DataListMenuItems" runat="server" ItemType="_1.MenuControl.Models.MenuItem"
    OnItemDataBound="DataListMenuItems_ItemDataBound" CssClass="menu">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="HyperLinkItem" runat="server" NavigateUrl="<%#: Item.Url %>" Text="<%#: Item.Text %>" CssClass="menu" />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:DataList>