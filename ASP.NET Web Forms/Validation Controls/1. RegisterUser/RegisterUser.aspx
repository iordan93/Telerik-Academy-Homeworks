<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="_1.RegisterUser.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register user</title>
    <style type="text/css">
        .error * {
            font-weight: bold;
            color: #ff0000;
            list-style-type: none;
        }

        .valid {
            font-weight: bold;
            font-size: 20px;
            color: #00ff00;
        }
    </style>
</head>
<body>
    <form id="FormRegisterUser" runat="server">
        <div>
            Username:
        <asp:TextBox ID="TextBoxUsername" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
                ErrorMessage="The username is required." ControlToValidate="TextBoxUsername" CssClass="error" Display="None" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorUsername" runat="server"
                ErrorMessage="The username must be between 6 and 40 characters long and contain only letters, numbers, dots, dashes and/or underscores."
                ControlToValidate="TextBoxUsername" ValidationExpression="^[A-Za-z0-9._-]{6,40}$" CssClass="error" Display="None" />
        </div>

        <div>
            Password:
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                ErrorMessage="The password is required." ControlToValidate="TextBoxPassword" CssClass="error" Display="None" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server"
                ErrorMessage="The password must be between 6 and 40 characters long and contain only letters, numbers, dots, dashes and/or underscores."
                ControlToValidate="TextBoxPassword" ValidationExpression="^[A-Za-z0-9._-]{6,40}$" CssClass="error" Display="None" />
        </div>

        <div>
            Repeat password:
        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" TextMode="Password" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server"
                ErrorMessage="The password must be entered twice." ControlToValidate="TextBoxRepeatPassword" CssClass="error" Display="None" />
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ErrorMessage="The passwords do not match." CssClass="error"
                ControlToValidate="TextBoxRepeatPassword" ControlToCompare="TextBoxPassword" Display="None" />
        </div>

        <div>
            First name:
        <asp:TextBox ID="TextBoxFirstName" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                ErrorMessage="The first name is required." ControlToValidate="TextBoxFirstName" CssClass="error" Display="None" />
        </div>

        <div>
            Last name:
        <asp:TextBox ID="TextBoxLastName" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                ErrorMessage="The last name is required." ControlToValidate="TextBoxLastName" CssClass="error" Display="None" />
        </div>

        <div>
            Age:
        <asp:TextBox ID="TextBoxAge" runat="server" TextMode="Number" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server"
                ErrorMessage="The age is required." ControlToValidate="TextBoxAge" CssClass="error" Display="None" />
            <asp:RangeValidator ID="RangeValidatorAge" runat="server"
                ErrorMessage="The age must be between 18 and 81." ControlToValidate="TextBoxAge" CssClass="error"
                MinimumValue="18" MaximumValue="81" Display="None" />
        </div>

        <div>
            Email:
        <asp:TextBox ID="TextBoxEmail" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                ErrorMessage="The email is required." ControlToValidate="TextBoxEmail" CssClass="error" Display="None" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                ErrorMessage="The email address is not in a correct format." CssClass="error" Display="None"
                ControlToValidate="TextBoxEmail" ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
        </div>

        <div>
            Local address:
        <asp:TextBox ID="TextBoxLocalAddress" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalAddress" runat="server" Display="None"
                ErrorMessage="The local address is required." ControlToValidate="TextBoxLocalAddress" CssClass="error" />
        </div>

        <div>
            Phone:
        <asp:TextBox ID="TextBoxPhone" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" Display="None"
                ErrorMessage="The phone is required." ControlToValidate="TextBoxPhone" CssClass="error" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" Display="None"
                ErrorMessage="The phone is not in a correct format. Only numbers and a leading '+' are allowed."
                ControlToValidate="TextBoxPhone" ValidationExpression="^\+?[0-9 ]+$" CssClass="error" />
        </div>

        <div>
            <asp:CheckBox ID="CheckBoxAcceptTerms" runat="server" Text="I accept" />
            <asp:CustomValidator ID="CustomValidatorAcceptTerms" runat="server"
                OnServerValidate="CustomValidatorAcceptTerms_ServerValidate" Display="None"
                ErrorMessage="Acceptance of the terms is required." CssClass="error" />
        </div>

        <div>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </div>
        <asp:ValidationSummary ID="ValidationSummaryResult" runat="server" CssClass="error" />
        <asp:Label ID="LabelResult" runat="server" />
    </form>
</body>
</html>
