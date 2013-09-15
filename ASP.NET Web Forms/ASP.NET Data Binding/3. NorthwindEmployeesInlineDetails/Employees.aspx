<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_3.NorthwindEmployeesInlineDetails.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <style type="text/css">
        td {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="Employees" runat="server">
        <h1>Employees</h1>
        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperlinkDetails" runat="server" NavigateUrl='<%# "Employees.aspx?id=" + Eval("EmployeeID") %>'>
                            <asp:Label ID="Name" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:FormView ID="FormViewEmployeeDetails" runat="server" ItemType="Northwind.Employee">
            <ItemTemplate>
                <ul>
                    <li>
                        <span><strong>Name:</strong> <%# Item.FirstName + " " + Item.LastName %></span>
                    </li>
                    <li>
                        <span><strong>Title:</strong> <%# Item.Title %></span>
                    </li>     
                    <li>      
                        <span><strong>Birth date:</strong> <%# Item.BirthDate %></span>
                    </li>     
                    <li>      
                        <span><strong>Address:</strong> <%# Item.Address %></span>
                    </li>     
                    <li>      
                        <span><strong>City:</strong> <%# Item.City %></span>
                    </li>     
                    <li>      
                        <span><strong>Region:</strong> <%# Item.Region %></span>
                    </li>     
                    <li>      
                        <span><strong>Postal code:</strong> <%# Item.PostalCode %></span>
                    </li>     
                    <li>      
                        <span><strong>Country:</strong> <%# Item.Country %></span>
                    </li>     
                    <li>      
                        <span><strong>Home phone:</strong> <%# Item.HomePhone + Item.Extension!=string.Empty?", ext. " + Item.Extension:"" %></span>
                    </li>
                    <li>
                        <span><strong>Notes:</strong> <%# Item.Notes %></span>
                    </li>
                    <li>
                        <span><strong>Photo path:</strong> <%# Item.PhotoPath %></span>
                    </li>
                </ul>
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
