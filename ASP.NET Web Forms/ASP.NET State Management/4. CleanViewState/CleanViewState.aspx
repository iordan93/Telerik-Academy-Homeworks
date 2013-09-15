<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CleanViewState.aspx.cs" Inherits="_4.CleanViewState.CleanViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clean ViewState</title>
</head>
<body>
    <h1>Clean ViewState</h1>

    <form id="formViewState" runat="server">
        <p>
            If the ViewState remains on the page, the browser keeps the entered value.
            Cleaning the ViewState results in data loss. When the page is posted back, the value disappears.
        </p>
        <asp:TextBox ID="TextBoxViewState" runat="server" />
        <asp:Button ID="ButtonDoPostback" runat="server" Text="Submit" />
    </form>
    <script>
        document.onload = function () {
            var viewState = document.getElementById("__VIEWSTATE");
            document.forms[0].children[0].removeChild(viewState);
        }();
    </script>
</body>
</html>