<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesAndOrders.aspx.cs" Inherits="_1.EmployeesAndOrders.EmployeesAndOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees and orders</title>
</head>
<body>
    <form id="FormEmployeesAndOrders" runat="server">
        <h1>Employees and orders</h1>

        <asp:ScriptManager ID="ScriptManagerMain" runat="server" />

        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false"
            ItemType="_1.EmployeesAndOrders.Employee" DataKeyNames="EmployeeID"
            OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" HeaderText="Select" />
                <asp:BoundField DataField="FirstName" HeaderText="First name" />
                <asp:BoundField DataField="LastName" HeaderText="Last name" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="BirthDate" HeaderText="Birth date" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="Postal code" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:BoundField DataField="HomePhone" HeaderText="Home phone" />
                <asp:BoundField DataField="Extension" HeaderText="Extension" />
            </Columns>
        </asp:GridView>
        <br />

        <asp:UpdateProgress ID="UpdateProgressOrders" runat="server">
            <ProgressTemplate>
                <asp:Image ID="ImageLoading" runat="server" ImageUrl="~/Images/ajax-loader.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanelOrders" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="false"
                    ItemType="_1.EmployeesAndOrders.Order" DataKeyNames="OrderID"
                    AllowPaging="true" PageSize="5" OnPageIndexChanging="GridViewOrders_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="OrderDate" HeaderText="Order date" DataFormatString="{0:dd.MM.yyyy}" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="Required date" DataFormatString="{0:dd.MM.yyyy}" />
                        <asp:BoundField DataField="ShippedDate" HeaderText="Shipped date" DataFormatString="{0:dd.MM.yyyy}" />
                        <asp:BoundField DataField="Freight" HeaderText="Freight" />
                        <asp:BoundField DataField="ShipName" HeaderText="Ship name" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="Ship country" />
                        <asp:BoundField DataField="ShipCity" HeaderText="Ship city" />
                        <asp:BoundField DataField="ShipAddress" HeaderText="Ship address" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewEmployees" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
