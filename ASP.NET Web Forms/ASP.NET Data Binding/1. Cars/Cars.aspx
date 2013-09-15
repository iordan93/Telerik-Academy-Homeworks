<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="_1.Cars.Cars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cars</title>
    <style type="text/css">
        .label {
            font-weight: bold;
        }

        #model {
            padding-left: 15px;
        }
    </style>
</head>
<body>
    <form id="Cars" runat="server">
        <span id="producer">
            <asp:Label ID="Producer" runat="server" Text="Producer: " CssClass="label" />
            <asp:DropDownList ID="DropDownListProducer" runat="server" DataTextField="Name"
                DataValueField="Name" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged">
            </asp:DropDownList>
        </span>
        <span id="model">
            <asp:Label ID="Model" runat="server" Text="Model: " CssClass="label" />
            <asp:DropDownList ID="DropDownListModel" runat="server">
            </asp:DropDownList>
        </span>
        <div>
            <asp:Label ID="TypeOfEngine" runat="server" Text="Type of engine: " CssClass="label" />
            <asp:RadioButtonList ID="RadioButtonListTypeOfEngine" runat="server" RepeatDirection="Horizontal" />
        </div>
        <div>
            <asp:Label ID="Extras" runat="server" Text="Extras: " CssClass="label" />
            <asp:CheckBoxList runat="server" ID="CheckBoxListExtras" RepeatDirection="Vertical" DataTextField="Name" DataValueField="Id" />
        </div>
        <div>
            <asp:Button Text="Submit" runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_Click" />
        </div>
        <div>
            <asp:Literal ID="LiteralResult" runat="server" />
        </div>
    </form>
</body>
</html>
