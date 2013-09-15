<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoLists.aspx.cs" Inherits="_4.TodoLists.TodoLists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo Lists</title>
    <style type="text/css">
        .error-message {
            display: block;
            color: #ff0000;
        }
    </style>
</head>
<body>
    <form id="TodoLists" runat="server">
        <asp:Label ID="LabelErrorMessages" runat="server" CssClass="error-message" EnableViewState="false" />

        <h1>Categories</h1>

        <asp:EntityDataSource ID="EntityDataSourceTodoCategories" runat="server"
            ConnectionString="name=TodoListsEntities"
            DefaultContainerName="TodoListsEntities"
            EntitySetName="Categories" />

        <asp:ListBox ID="ListBoxCategories" runat="server" Rows="6" Width="150px"
            DataSourceID="EntityDataSourceTodoCategories"
            DataTextField="Name" DataValueField="CategoryId"
            OnSelectedIndexChanged="ListBoxCategories_SelectedIndexChanged"
            AutoPostBack="True" /><br />

        <asp:Button ID="ButtonInsertCategory" Text="Insert category" runat="server"
            OnClick="ButtonInsertCategory_Click" />
        <asp:Button ID="ButtonEditCategory" Text="Edit category" runat="server"
            OnClick="ButtonEditCategory_Click" Visible="false" />
        <asp:Button ID="ButtonDeleteCategory" Text="Delete category" runat="server"
            OnClick="ButtonDeleteCategory_Click" Visible="false" />

        <asp:Panel ID="PanelInsertCategory" runat="server" Visible="false">
            Category name:
            <asp:TextBox runat="server" ID="TextBoxCategoryName" />
            <asp:Button Text="Save" ID="ButtonEditExistingCategory" runat="server" OnClick="ButtonEditExistingCategory_Click" Visible="false" />
            <asp:Button Text="Save" ID="ButtonSaveCategory" runat="server" OnClick="ButtonSaveCategory_Click" Visible="false" />
        </asp:Panel>

        <h2>Todo Lists</h2>

        <asp:EntityDataSource ID="EntityDataSourceTodoLists" runat="server"
            ConnectionString="name=TodoListsEntities"
            DefaultContainerName="TodoListsEntities"
            EntitySetName="TodoLists"
            Where="it.CategoryId=@CategoryId" EnableFlattening="False"
            EnableDelete="true" EnableUpdate="true" EnableInsert="true">
            <WhereParameters>
                <asp:ControlParameter Name="CategoryId" Type="Int32"
                    ControlID="ListBoxCategories" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:ListView ID="ListViewTodoLists" runat="server"
            DataSourceID="EntityDataSourceTodoLists" ItemType="_4.TodoLists.TodoList"
            DataKeyNames="TodoListId">

            <LayoutTemplate>
                <span runat="server" id="itemPlaceholder" />
                <div class="pagerLine">
                    <asp:Button ID="ButtonInsertTodoList" Text="Insert todo" runat="server" OnClick="ButtonInsertTodoList_Click" />
                    <asp:DataPager ID="DataPagerTodoLists" runat="server" PageSize="2">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" ShowLastPageButton="false" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowPreviousPageButton="false" ShowNextPageButton="true" ShowLastPageButton="true" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>

            <EmptyDataTemplate>
                <asp:Button ID="ButtonInsertTodoList" Text="Insert todo" runat="server" OnClick="ButtonInsertTodoList_Click" />
                <div>No data was returned.</div>
            </EmptyDataTemplate>

            <ItemTemplate>
                <div class="item">
                    Title: <%#: Item.Title %>
                    <br />
                    Text: <%#: Item.Text %>
                    <br />
                    Last change date: <%#: string.Format("{0:dd.MM.yyyy}", Item.LastChangeDate) %>
                    <br />

                    <asp:Button ID="ButtonEdit" runat="server" Text="Edit"
                        CommandName="Edit" CommandArgument="<%#: Item.TodoListId %>" OnCommand="ButtonEdit_Command" />
                    <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                </div>
            </ItemTemplate>
        </asp:ListView>

        <asp:Panel ID="PanelInsertTodoList" runat="server" Visible="false" EnableViewState="false">
            Title:
            <asp:TextBox ID="TextBoxTodoTitle" runat="server" />
            <br />
            Text:
            <asp:TextBox ID="TextBoxTodoText" runat="server" />
            <br />
            <asp:Button ID="ButtonSaveTodoList" runat="server" Text="Save" OnClick="ButtonSaveTodoList_Click" />
        </asp:Panel>

        <asp:Panel ID="PanelEditTodoList" runat="server" Visible="false">
            Title:
            <asp:TextBox ID="TextBoxEditedTitle" runat="server" />
            <br />
            Text:
            <asp:TextBox ID="TextBoxEditedText" runat="server" />
            <br />
            <asp:Button ID="ButtonEditTodoList" runat="server" Text="Save" OnClick="ButtonEditTodoList_Click" />
        </asp:Panel>

    </form>
</body>
</html>
