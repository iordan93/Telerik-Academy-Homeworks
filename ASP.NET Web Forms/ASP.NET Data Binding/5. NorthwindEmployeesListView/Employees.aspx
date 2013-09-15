<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_5.NorthwindEmployeesListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <style>
        .name {
            padding-top: 20px;
            padding-bottom: 20px;
            font-size: 18px;
        }

        tr td:first-of-type{
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="Employees" runat="server">
        <asp:ListView ID="ListViewEmployees" runat="server" ItemType="Northwind.Employee">
            <LayoutTemplate>
                <h1>Employees</h1>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="name"><strong><%#: Item.FirstName + " "  + Item.LastName %></strong></div>
                <table>
                    <tr>
                        <td><strong>First name</strong></td>
                        <td><%#: Item.FirstName %></td>
                    </tr>
                    <tr>
                        <td><strong>Last name</strong></td>
                        <td><%#: Item.LastName %></td>
                    </tr>
                    <tr>
                        <td><strong>Title</strong></td>
                        <td><%#: Item.Title %></td>
                    </tr>
                    <tr>
                        <td><strong>Birth date</strong></td>
                        <td><%#: string.Format("{0:dd.MM.yyyy}", Item.BirthDate) %></td>
                    </tr>
                    <tr>
                        <td><strong>Address</strong></td>
                        <td><%#: Item.Address %></td>
                    </tr>
                    <tr>
                        <td><strong>City</strong></td>
                        <td><%#: Item.City %></td>
                    </tr>
                    <tr>
                        <td><strong>Region</strong></td>
                        <td><%#: Item.Region %></td>
                    </tr>
                    <tr>
                        <td><strong>Postal code</strong></td>
                        <td><%#: Item.PostalCode %></td>
                    </tr>
                    <tr>
                        <td><strong>Country</strong></td>
                        <td><%#: Item.Country %></td>
                    </tr>
                    <tr>
                        <td><strong>Home phone</strong></td>
                        <td><%#: Item.HomePhone %></td>
                    </tr>
                    <tr>
                        <td><strong>Extension</strong></td>
                        <td><%#: Item.Extension %></td>
                    </tr>
                    <tr>
                        <td><strong>Notes</strong></td>
                        <td><%#: Item.Notes %></td>
                    </tr>
                    <tr>
                        <td><strong>Photo path</strong></td>
                        <td><%#: Item.PhotoPath %></td>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
        </asp:ListView>
    </form>
</body>
</html>
