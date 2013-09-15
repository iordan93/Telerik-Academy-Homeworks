<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_2.NorthwindEmployees.Employees" %>

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
                        <asp:HyperLink ID="HyperlinkDetails" runat="server" NavigateUrl='<%# "EmpDetails.aspx?id=" + Eval("EmployeeID") %>'>
                            <asp:Label ID="Name" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
