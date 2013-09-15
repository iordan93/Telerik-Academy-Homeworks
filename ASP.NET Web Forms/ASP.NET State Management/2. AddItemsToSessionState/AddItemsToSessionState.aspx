<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItemsToSessionState.aspx.cs" Inherits="_2.AddItemsToSessionState.AddItemsToSessionState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SessionState</title>
</head>
<body>
    <form id="mainForm" runat="server">
        <h1>Add items to SessionState</h1>
        <asp:Panel ID="PanelAddItemToSessionState" runat="server">
            <asp:TextBox ID="InputText" runat="server" EnableViewState="false" />
            <asp:Button ID="ButtonAddToSessionState" runat="server"
                Text="Append text to SessionState" OnClick="ButtonAddToSessionState_Click" />
        </asp:Panel>

        <asp:Panel ID="PanelShowSessionStateItem" runat="server" Visible="false">
            <asp:Label ID="LabelSessionStateItem" runat="server"  />
            <br />
            <asp:Button ID="ButtonBack" runat="server" Text="Back"
                OnClick="ButtonBack_Click" />
        </asp:Panel>
    </form>
</body>
</html>
