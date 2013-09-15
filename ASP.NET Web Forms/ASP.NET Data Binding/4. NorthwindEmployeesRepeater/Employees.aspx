<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_4.NorthwindEmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <style type="text/css">
        table {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="Employees" runat="server">
        <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="Northwind.Employee">
            <HeaderTemplate>
                <h1>Employees</h1>
                <table border="1">
                    <thead>
                        <tr>
                            <th>First name</th>
                            <th>Last name</th>
                            <th>Title</th>
                            <th>Birth date</th>
                            <th>Address</th>
                            <th>City</th>
                            <th>Region</th>
                            <th>Postal code</th>
                            <th>Country</th>
                            <th>Home phone</th>
                            <th>Extension</th>
                            <th>Notes</th>
                            <th>Photo path</th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.FirstName %></td>
                    <td><%#: Item.LastName %></td>
                    <td><%#: Item.Title %></td>
                    <td><%#: string.Format("{0:dd.MM.yyyy}", Item.BirthDate) %></td>
                    <td><%#: Item.Address %></td>
                    <td><%#: Item.City %></td>
                    <td><%#: Item.Region %></td>
                    <td><%#: Item.PostalCode %></td>
                    <td><%#: Item.Country %></td>
                    <td><%#: Item.HomePhone %></td>
                    <td><%#: Item.Extension %></td>
                    <td><%#: Item.Notes %></td>
                    <td><%#: Item.PhotoPath %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
