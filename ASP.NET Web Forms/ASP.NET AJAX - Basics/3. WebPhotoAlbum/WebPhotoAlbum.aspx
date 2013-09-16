<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPhotoAlbum.aspx.cs" Inherits="_3.WebPhotoAlbum.WebPhotoAlbum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web photo album</title>
    <style type="text/css">
        body {
            margin: 50px 0px;
            text-align: center;
        }
    </style>
    <script src="Scripts/jquery-2.0.3.js"></script>
</head>
<body>
    <form id="FormWebPhotoAlbum" runat="server">
        <h1>Web photo album</h1>

        <ajaxToolkit:ToolkitScriptManager ID="ScriptManager" runat="server" />

        <asp:Image ID="ImageContainer" runat="server" Height="300px" ImageUrl="~/Images/cat1.jpg" />

        <ajaxToolkit:SlideShowExtender ID="SlideShowExtenderWebPhotoAlbum" runat="server"
            BehaviorID="SSBehaviorID"
            TargetControlID="ImageContainer"
            SlideShowServiceMethod="GetSlides"
            AutoPlay="true"
            ImageDescriptionLabelID="LabelDescription"
            NextButtonID="ButtonNext"
            PreviousButtonID="ButtonPrevious"
            PlayButtonID="ButtonPlay"
            PlayButtonText="Play"
            StopButtonText="Stop"
            Loop="true">
        </ajaxToolkit:SlideShowExtender>

        <div>
            <asp:Label ID="LabelDescription" runat="server"></asp:Label><br />
            <asp:Button ID="ButtonPrevious" runat="server" Text="Previous" />
            <asp:Button ID="ButtonPlay" runat="server" />
            <asp:Button ID="ButtonNext" runat="server" Text="Next" />
        </div>
    </form>
    <script src="Scripts/script.js"></script>
</body>
</html>
