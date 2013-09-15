<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="_2.RegisterUserWithValidationGroups.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register user</title>
    <style type="text/css">
        .error {
            font-weight: bold;
            color: #ff0000;
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
        <asp:Panel ID="PanelLogonInfo" runat="server" GroupingText="Logon information">
            <div>
                Username:
            <asp:TextBox ID="TextBoxUsername" runat="server" ValidationGroup="LogonInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The username is required." ControlToValidate="TextBoxUsername" CssClass="error" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorUsername" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The username must be between 6 and 40 characters long and contain only letters, numbers, dots, dashes and/or underscores."
                    ControlToValidate="TextBoxUsername" ValidationExpression="^[A-Za-z0-9._-]{6,40}$" CssClass="error" Display="Dynamic" />
            </div>

            <div>
                Password:
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" ValidationGroup="LogonInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The password is required." ControlToValidate="TextBoxPassword" CssClass="error" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The password must be between 6 and 40 characters long and contain only letters, numbers, dots, dashes and/or underscores."
                    ControlToValidate="TextBoxPassword" ValidationExpression="^[A-Za-z0-9._-]{6,40}$" CssClass="error" Display="Dynamic" />
            </div>

            <div>
                Repeat password:
        <asp:TextBox ID="TextBoxRepeatPassword" runat="server" TextMode="Password" ValidationGroup="LogonInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The password must be entered twice." ControlToValidate="TextBoxRepeatPassword" CssClass="error" Display="Dynamic" />
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ValidationGroup="LogonInfo"
                    ErrorMessage="The passwords do not match." CssClass="error"
                    ControlToValidate="TextBoxRepeatPassword" ControlToCompare="TextBoxPassword" Display="Dynamic" />
            </div>

            <div>
                <asp:Button ID="ButtonValidateLogonInfo" runat="server" CausesValidation="true" ValidationGroup="LogonInfo"
                    Text="Validate logon information" OnClick="ButtonValidateLogonInfo_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelPersonalInfo" runat="server" GroupingText="Personal information">
            <div>
                First name:
        <asp:TextBox ID="TextBoxFirstName" runat="server" ValidationGroup="PersonalInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The first name is required." ControlToValidate="TextBoxFirstName" CssClass="error" Display="Dynamic" />
            </div>

            <div>
                Last name:
        <asp:TextBox ID="TextBoxLastName" runat="server" ValidationGroup="PersonalInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The last name is required." ControlToValidate="TextBoxLastName" CssClass="error" Display="Dynamic" />
            </div>

            <div>
                Age:
        <asp:TextBox ID="TextBoxAge" runat="server" ValidationGroup="PersonalInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The age is required." ControlToValidate="TextBoxAge" CssClass="error" Display="Dynamic" />
                <asp:RangeValidator ID="RangeValidatorAge" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The age must be between 18 and 81." ControlToValidate="TextBoxAge" CssClass="error"
                    MinimumValue="18" MaximumValue="81" Display="Dynamic" />
            </div>

            <div>
                Email:
        <asp:TextBox ID="TextBoxEmail" runat="server" ValidationGroup="PersonalInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The email is required." ControlToValidate="TextBoxEmail" CssClass="error" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ValidationGroup="PersonalInfo"
                    ErrorMessage="The email address is not in a correct format." CssClass="error" Display="Dynamic"
                    ControlToValidate="TextBoxEmail" ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />
            </div>

            <div>
                <asp:Button ID="ButtonValidatePersonalInfo" runat="server" CausesValidation="true" ValidationGroup="PersonalInfo"
                    Text="Validate personal information" OnClick="ButtonValidatePersonalInfo_Click" />
            </div>
        </asp:Panel>

        <asp:Panel ID="PanelAddressInfo" runat="server" GroupingText="Address information">
            <div>
                Local address:
        <asp:TextBox ID="TextBoxLocalAddress" runat="server" ValidationGroup="AddressInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalAddress" runat="server" ValidationGroup="AddressInfo" Display="Dynamic"
                    ErrorMessage="The local address is required." ControlToValidate="TextBoxLocalAddress" CssClass="error" />
            </div>

            <div>
                Phone:
        <asp:TextBox ID="TextBoxPhone" runat="server" ValidationGroup="AddressInfo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ValidationGroup="AddressInfo" Display="Dynamic"
                    ErrorMessage="The phone is required." ControlToValidate="TextBoxPhone" CssClass="error" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ValidationGroup="AddressInfo" Display="Dynamic"
                    ErrorMessage="The phone is not in a correct format. Only numbers and a leading '+' are allowed."
                    ControlToValidate="TextBoxPhone" ValidationExpression="^\+?[0-9 ]+$" CssClass="error" />
            </div>

            <div>
                <asp:CheckBox ID="CheckBoxAcceptTerms" runat="server" Text="I accept" ValidationGroup="AddressInfo" />
                <asp:CustomValidator ID="CustomValidatorAcceptTerms" runat="server"
                    OnServerValidate="CustomValidatorAcceptTerms_ServerValidate" Display="Dynamic"
                    ErrorMessage="Acceptance of the terms is required." CssClass="error" ValidationGroup="AddressInfo" />
            </div>

            <div>
                <asp:Button ID="ButtonValidateAddressInfo" runat="server" CausesValidation="true" ValidationGroup="AddressInfo"
                    Text="Validate address information" OnClick="ButtonValidateAddressInfo_Click" />
            </div>
        </asp:Panel>

        <asp:Label ID="LabelResult" runat="server" />
    </form>
</body>
</html>
