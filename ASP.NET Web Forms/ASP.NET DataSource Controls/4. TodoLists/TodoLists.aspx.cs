using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _4.TodoLists
{
    public partial class TodoLists : System.Web.UI.Page
    {
        private const string NoCategorySelectedError = "There is no selected category to insert a todo.";

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.ListViewTodoLists.DataBind();
        }

        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            this.PanelInsertCategory.Visible = true;

            this.ButtonSaveCategory.Visible = true;
            this.ButtonEditExistingCategory.Visible = false;
        }

        protected void ButtonEditCategory_Click(object sender, EventArgs e)
        {
            using (var context = new TodoListsEntities())
            {
                var category = context.Categories.Find(int.Parse(this.ListBoxCategories.SelectedValue));
                this.TextBoxCategoryName.Text = category.Name;
            }

            this.PanelInsertCategory.Visible = true;
            this.ButtonEditCategory.Visible = false;

            this.ButtonEditExistingCategory.Visible = true;
            this.ButtonSaveCategory.Visible = false;
        }

        protected void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            using (var context = new TodoListsEntities())
            {
                var categoryToRemove = context.Categories.Find(int.Parse(this.ListBoxCategories.SelectedValue));
                context.TodoLists.RemoveRange(categoryToRemove.TodoLists);
                context.Categories.Remove(categoryToRemove);
                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ButtonEditExistingCategory_Click(object sender, EventArgs e)
        {
            CreateOrUpdateCategory(false);
        }

        protected void ButtonSaveCategory_Click(object sender, EventArgs e)
        {
            CreateOrUpdateCategory(true);
        }

        protected void ListViewTodoLists_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewTodoLists.InsertItemPosition = InsertItemPosition.None;
            this.ListViewTodoLists.DataBind();
        }

        protected void ButtonInsertTodoList_Click(object sender, EventArgs e)
        {
            this.PanelEditTodoList.Visible = false;
            this.PanelInsertTodoList.Visible = true;
        }

        protected void ButtonSaveTodoList_Click(object sender, EventArgs e)
        {
            try
            {
                CreateOrUpdateTodoList(true);
            }
            catch (FormatException)
            {
                this.LabelErrorMessages.Text = NoCategorySelectedError;
            }
            catch (Exception ex)
            {
                this.LabelErrorMessages.Text = ex.Message;
            }

            this.PanelInsertTodoList.Visible = false;
        }

        protected void ButtonEditTodoList_Click(object sender, EventArgs e)
        {
            CreateOrUpdateTodoList(false);
            this.PanelEditTodoList.Visible = false;
        }

        private void CreateOrUpdateTodoList(bool create = false)
        {
            using (var context = new TodoListsEntities())
            {
                var category = context.Categories.Find(int.Parse(ListBoxCategories.SelectedValue));

                if (create)
                {
                    TodoList todoList = new TodoList();
                    todoList.Category = category;
                    todoList.Title = this.TextBoxTodoTitle.Text;
                    todoList.Text = this.TextBoxTodoText.Text;
                    todoList.LastChangeDate = DateTime.Now;

                    context.TodoLists.Add(todoList);
                    context.SaveChanges();
                }
                else
                {
                    int todoListId = int.Parse(this.ButtonEditTodoList.CommandArgument);
                    var todoToUpdate = context.TodoLists.Find(todoListId);
                    todoToUpdate.Title = this.TextBoxEditedTitle.Text;
                    todoToUpdate.Text = this.TextBoxEditedText.Text;
                    todoToUpdate.LastChangeDate = DateTime.Now;

                    context.SaveChanges();
                }

                this.ListViewTodoLists.DataBind();
            }
        }

        private void CreateOrUpdateCategory(bool create = true)
        {
            string categoryName = this.TextBoxCategoryName.Text;
            if (string.IsNullOrEmpty(categoryName))
            {
                return;
            }
            using (var context = new TodoListsEntities())
            {
                if (create)
                {

                    context.Categories.Add(new Category()
                    {
                        Name = categoryName
                    });

                    context.SaveChanges();

                }
                else
                {
                    var existingCategory = context.Categories.Find(int.Parse(this.ListBoxCategories.SelectedValue));
                    existingCategory.Name = this.TextBoxCategoryName.Text;
                    context.SaveChanges();
                }
            }

            this.ListBoxCategories.DataBind();
            this.PanelInsertCategory.Visible = false;
        }
        protected void ButtonEdit_Command(object sender, CommandEventArgs e)
        {
            this.PanelEditTodoList.Visible = true;
            this.ButtonEditTodoList.CommandArgument = e.CommandArgument.ToString();
            using (var context = new TodoListsEntities())
            {
                var todoToUpdate = context.TodoLists.Find(Convert.ToInt32(e.CommandArgument));
                this.TextBoxEditedTitle.Text = todoToUpdate.Title;
                this.TextBoxEditedText.Text = todoToUpdate.Text;
            }
        }

        protected void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ButtonDeleteCategory.Visible = true;
            this.ButtonEditCategory.Visible = true;
            this.ButtonInsertCategory.Visible = true;
        }
    }
}