<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHello.aspx.cs" Inherits="_1.SayHello.SayHello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Say Hello</title>
</head>
<body>
    <form id="EnterName" runat="server">
        <asp:Label ID="Name" AssociatedControlID="TextBoxName" runat="server">Enter your name: </asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" /><br />
        <asp:Literal ID="LiteralResult" runat="server" Mode="Encode"></asp:Literal>
    </form>
</body>
</html>
