<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="_2a.SumNumbersWebForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Sum numbers - WebForms</title>
    <style type="text/css">
        .label {
            display: inline-block;
            width: 120px;
        }
    </style>
</head>
<body>
    <h1>Summator</h1>
    <p>Please use your system's default decimal separator to sum floating-point numbers.</p>
    <form id="FormSumNumbers" runat="server">
        <asp:Label ID="FirstNumber" runat="server" CssClass="label">First number:</asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server" Text="0"></asp:TextBox><br />
        <asp:Label ID="SecondNumber" runat="server" CssClass="label">Second number:</asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server" Text="0"></asp:TextBox><br />
        <asp:Button ID="ButtonSumNumbers" runat="server" Text="Sum numbers" OnClick="ButtonSumNumbers_Click" /><br />
        <asp:Label ID="Result" runat="server" AssociatedControlID="TextBoxResult" CssClass="label">Result:</asp:Label>
        <asp:TextBox ID="TextBoxResult" runat="server" ReadOnly="true" Columns="30"></asp:TextBox>
    </form>
</body>
</html>
