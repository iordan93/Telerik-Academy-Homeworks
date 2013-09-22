<%@ Page Title="Caching Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1.CachingData._Default" %>

<%@ Register Src="~/Controls/CachedControl.ascx" TagPrefix="custom" TagName="CachedControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Caching data</h1>

    <div class="row">
        <div class="span12">
            <asp:HyperLink ID="HyperLinkCachedAboutPage" runat="server" NavigateUrl="~/About.aspx" Text="Cached About page (1 hour)" />
        </div>

        <div class="span12">
            <div>Cached control (10 seconds): </div>
            <custom:CachedControl runat="server" ID="CachedControlDateTime" />
        </div>
    </div>

</asp:Content>
