<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuControlDemo.aspx.cs" Inherits="_1.MenuControl.MenuControlDemo" %>

<%@ Register Src="~/Controls/MenuControl/MenuControl.ascx" TagPrefix="custom" TagName="MenuControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Control Demo</title>
</head>
<body>
    <form id="FormMenuControlDemo" runat="server">
        <custom:MenuControl runat="server" ID="MenuControlMain" FontColor="#00ff00" FontName="Segoe UI" RepeatDirection="Horizontal" />
    </form>
</body>
</html>
