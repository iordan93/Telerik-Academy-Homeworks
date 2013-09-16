<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebChat.aspx.cs" Inherits="_2.WebChat.WebChat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web chat</title>
    <style type="text/css">
        .error {
            color: #ff0000;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="FormWebChat" runat="server">
        <asp:ScriptManager ID="ScriptManagerMain" runat="server" />

        <h1>Web chat</h1>
        Username:
        <asp:TextBox ID="TextBoxUsername" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="TextBoxUsername" Display="Dynamic"
            ErrorMessage="The username is required." CssClass="error" />
        <br />
        Message:
        <asp:TextBox ID="TextBoxMessage" runat="server" EnableViewState="false" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" ControlToValidate="TextBoxMessage" Display="Dynamic"
            ErrorMessage="The message is required." CssClass="error" />
        
        <asp:UpdatePanel ID="UpdatePanelNewMessage" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Button ID="ButtonSendMessage" runat="server" Text="Send" OnClick="ButtonSendMessage_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ListViewMessages" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Timer ID="TimerMessages" runat="server" Interval="5000" OnTick="TimerMessages_Tick" />
        <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <h2>Messages</h2>
                <asp:ListView ID="ListViewMessages" runat="server"
                    ItemType="_2.WebChat.Models.Message" SelectMethod="ListViewMessages_GetData"
                    DataKeyNames="Id">

                    <LayoutTemplate>
                        <span runat="server" id="itemPlaceholder" />
                        <asp:DataPager ID="DataPagerMessages" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                                    ShowPreviousPageButton="true" ShowLastPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                                    ShowPreviousPageButton="false" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <div>
                            <strong><%#: string.Format("[{0:dd.MM.yyyy HH:mm:ss}] {1}:", Item.CreationDate, Item.Author.Username) %></strong>
                            <%#: Item.Text %>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerMessages" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
