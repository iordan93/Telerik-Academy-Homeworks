<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="_4.StudentRegistration.StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
</head>
<body>
    <h1>Student Registration</h1>
    <form id="StudentRegistration" runat="server">
        <asp:Label runat="server" ID="FirstName" Text="First name: " />
        <asp:TextBox runat="server" ID="TextBoxFirstName" /><br />
        <asp:Label runat="server" ID="LastName" Text="Last name: " />
        <asp:TextBox runat="server" ID="TextBoxLastName" /><br />
        <asp:Label runat="server" ID="University" Text="University: " />
        <asp:DropDownList runat="server" ID="DropDownUniversity">
            <asp:ListItem Text="Telerik Academy" />
            <asp:ListItem Text="Harvard University" />
            <asp:ListItem Text="Massachusetts Institute of Technology" />
            <asp:ListItem Text="Yale University" />
            <asp:ListItem Text="Princeton University" />
            <asp:ListItem Text="California Institute of Technology" />
            <asp:ListItem Text="University of Pennsylvania" />
            <asp:ListItem Text="Stanford University" />
            <asp:ListItem Text="University of Michigan" />
            <asp:ListItem Text="University of Chicago" />
        </asp:DropDownList><br />
        <asp:Label runat="server" ID="Speciality" Text="Speciality: " />
        <asp:DropDownList runat="server" ID="DropDownSpeciality">
            <asp:ListItem Text="Informatics" />
            <asp:ListItem Text="Computer Science" />
            <asp:ListItem Text="Astronomy" />
            <asp:ListItem Text="Mathematics" />
            <asp:ListItem Text="Aerospace Engineering" />
            <asp:ListItem Text="Earth, Atmospheric and Planetary Sciences" />
            <asp:ListItem Text="Applied Physics" />
            <asp:ListItem Text="Bioengineering" />
            <asp:ListItem Text="Materials Science" />
            <asp:ListItem Text="Chemistry" />
        </asp:DropDownList><br />
        <asp:Label runat="server" ID="Courses" Text="Courses: "/>
        <asp:ListBox runat="server" ID="ListBoxCourses" SelectionMode="Multiple">
            <asp:ListItem Text="Astronomy 101" />
            <asp:ListItem Text="Fundamentals of Calculus" />
            <asp:ListItem Text="Probability Theory and Statistics" />
            <asp:ListItem Text="Principles of Inorganic Chemistry I" />
            <asp:ListItem Text="Statistical Thermodynamics" />
            <asp:ListItem Text="Advanced Quantum Physics" />
            <asp:ListItem Text="Modern Astrophysics" />
            <asp:ListItem Text="Fluid Mechanics" />
            <asp:ListItem Text="Automata, Computability and Complexity" />
            <asp:ListItem Text="Design and Analysis of Algorithms" />
        </asp:ListBox><br />
        <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" />
    </form>
</body>
</html>
