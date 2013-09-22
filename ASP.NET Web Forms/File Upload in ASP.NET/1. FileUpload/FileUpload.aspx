<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="_1.FileUpload.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
    <link href="Styles/kendo.common.min.css" rel="stylesheet" />
    <link href="Styles/kendo.metro.min.css" rel="stylesheet" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/kendo.web.min.js"></script>
</head>
<body>
    <p>You can find a file named <strong>files.zip</strong> in the main project folder. Try to upload it.</p>
    <p>If uploading goes on successfully and you see the green strip, open the database to view the files.</p>

    <input name="fileUpload" id="fileUpload" type="file" />
    
    <script>
        $(document).ready(function () {
            $("#fileUpload").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    removeUrl: "Remove.aspx",
                    autoUpload: true,
                }
            });
        });
    </script>
</body>
</html>
