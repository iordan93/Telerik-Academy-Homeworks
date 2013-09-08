<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberGeneratorWebControls.aspx.cs" Inherits="_2.RandomNumberGeneratorWebControls.RandomNumberGeneratorWebControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Number Generator</title>
</head>
<body>
    <form id="RandomNumberGenerator" runat="server">
        <asp:Label runat="server" ID="MinNumber" AssociatedControlID="TextBoxMinNumber">Min number:</asp:Label>
        <asp:TextBox runat="server" ID="TextBoxMinNumber"></asp:TextBox><br />
        <asp:Label runat="server" ID="MaxNumber" AssociatedControlID="TextBoxMaxNumber">Max number:</asp:Label>
        <asp:TextBox runat="server" ID="TextBoxMaxNumber"></asp:TextBox><br />
        <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" text="Submit"/><br />
        <asp:Literal runat="server" ID="Result"></asp:Literal>
    </form>
</body>
</html>
