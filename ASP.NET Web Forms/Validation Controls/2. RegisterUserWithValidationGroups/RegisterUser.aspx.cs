using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2.RegisterUserWithValidationGroups
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CustomValidatorAcceptTerms_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAcceptTerms.Checked;
        }

        protected void ButtonValidateLogonInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelResult.Text = "The logon information is valid.";
                this.LabelResult.CssClass = "valid";
            }
        }

        protected void ButtonValidatePersonalInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelResult.Text = "The personal information is valid.";
                this.LabelResult.CssClass = "valid";
            }
        }

        protected void ButtonValidateAddressInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelResult.Text = "The address information is valid.";
                this.LabelResult.CssClass = "valid";
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelResult.Text = "The entered data is valid.";
                this.LabelResult.CssClass = "valid";
            }
        }
    }
}