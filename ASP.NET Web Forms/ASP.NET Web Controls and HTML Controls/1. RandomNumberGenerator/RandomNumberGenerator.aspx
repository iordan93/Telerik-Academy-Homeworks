<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberGenerator.aspx.cs" Inherits="_1.RandomNumberGenerator.RandomNumberGenerator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Number Generator</title>
</head>
<body>
    <form id="RandomNumberGenerator" runat="server">
        <label for="MinNumber">Min number:</label>
        <input type="text" id="MinNumber" runat="server" /><br />
        <label for="MaxNumber">Max number:</label>
        <input type="text" id="MaxNumber" runat="server" /><br />
        <input type="submit" id="Submit" runat="server" onserverclick="Submit_ServerClick" /><br />
        <span id="Result" runat="server"></span>
    </form>
</body>
</html>
