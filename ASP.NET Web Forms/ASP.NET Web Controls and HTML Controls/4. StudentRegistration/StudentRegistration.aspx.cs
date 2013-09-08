using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _4.StudentRegistration
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            HtmlGenericControl wrapper = new HtmlGenericControl("div");

            HtmlGenericControl heading = new HtmlGenericControl("h1");
            heading.InnerText = "Student Registration Result";
            wrapper.Controls.Add(heading);

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Student name: " + this.TextBoxFirstName.Text + " " + this.TextBoxLastName.Text
            });

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "University: " + this.DropDownUniversity.SelectedItem.Text
            });

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Speciality: " + this.DropDownSpeciality.SelectedItem.Text
            });

            List<string> courses = new List<string>();
            for (int i = 0; i < this.ListBoxCourses.Items.Count; i++)
            {
                if (this.ListBoxCourses.Items[i].Selected)
                {
                    courses.Add(this.ListBoxCourses.Items[i].Text);
                }
            }

            wrapper.Controls.Add(new HtmlGenericControl("div")
            {
                InnerText = "Courses: " + string.Join(", ", courses)
            });

            Page.Controls.Add(wrapper);
        }
    }
}