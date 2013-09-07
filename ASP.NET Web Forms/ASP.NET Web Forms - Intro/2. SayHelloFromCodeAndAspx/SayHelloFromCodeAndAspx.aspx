<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHelloFromCodeAndAspx.aspx.cs" Inherits="_2.SayHelloFromCodeAndAspx.SayHelloFromCodeAndAspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Say "Hello" from C# code and ASPX</title>
</head>
<body>
    <form id="SayHelloFromCodeAndAspx" runat="server">
        <asp:PlaceHolder ID="PlaceholderHello" runat="server"></asp:PlaceHolder><br />
        <asp:Literal ID="TextBoxHello" runat="server" Text="Hello from ASPX code!"></asp:Literal><br />
        <asp:Literal ID="TextBoxAssembly" runat="server"></asp:Literal>
    </form>
</body>
</html>
