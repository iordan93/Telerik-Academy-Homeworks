using _1.Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _1.Cars
{
    public partial class Cars : System.Web.UI.Page
    {
        static List<Producer> producers = ModelsData.GetProducers();
        static List<string> engineTypes = ModelsData.GetEngineTypes();
        static List<Extra> extras = ModelsData.GetExtras();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DropDownListProducer.DataSource = producers;
                this.RadioButtonListTypeOfEngine.DataSource = engineTypes;
                this.CheckBoxListExtras.DataSource = extras;
                Page.DataBind();

                this.DropDownListModel.DataSource = producers.FirstOrDefault(p => p.Name == this.DropDownListProducer.SelectedValue).Models;
                Page.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Selected model: {0} {1} <br />", this.DropDownListProducer.SelectedItem.Text, this.DropDownListModel.SelectedItem.Text);
            builder.AppendFormat("Type of engine: {0} <br />", this.RadioButtonListTypeOfEngine.SelectedValue).AppendLine();

            var extras = new List<string>();
            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (this.CheckBoxListExtras.Items[i].Selected)
                {
                    extras.Add(this.CheckBoxListExtras.Items[i].Text);
                }
            }

            builder.AppendFormat("Extras: {0}", string.Join(", ", extras)).AppendLine();
            this.LiteralResult.Text = builder.ToString();
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProducer = this.DropDownListProducer.SelectedValue;
            this.DropDownListModel.DataSource = producers.Where(p => p.Name == selectedProducer).FirstOrDefault().Models;

            this.DropDownListModel.DataBind();
        }
    }
}