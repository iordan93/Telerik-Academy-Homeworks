<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_2.NorthwindEmployees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Details</title>
    <style type="text/css">
        tr > td:first-child {
            width: 100px;
            font-weight: bold;
        }

        td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="EmployeeDetails" runat="server">
        <asp:DetailsView ID="DetailsViewEmployee" runat="server" DataMember="Employee" AutoGenerateRows="false">
            <Fields>
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
                <asp:BoundField DataField="Notes" HeaderText="Notes" />
                <asp:BoundField DataField="PhotoPath" HeaderText="Photo URL" />
            </Fields>
        </asp:DetailsView>

        <asp:Button runat="server" ID="ButtonBack" Text="Back" OnClick="ButtonBack_Click" />
    </form>
</body>
</html>
