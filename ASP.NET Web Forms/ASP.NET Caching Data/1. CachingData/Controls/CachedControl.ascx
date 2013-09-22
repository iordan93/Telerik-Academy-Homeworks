<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CachedControl.ascx.cs" Inherits="_1.CachingData.Controls.CachedControl" %>
<%@ OutputCache Duration="10" VaryByParam="*" %>

<asp:Label ID="LabelDateTime" runat="server"><%= DateTime.Now %></asp:Label>