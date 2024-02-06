<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="UFS_Application.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBox ID="chboxSelectHead" runat="server" AutoPostBack="true" OnCheckedChanged="chboxSelectHead_CheckedChanged"  />
    </div>
    </form>
</body>
</html>
