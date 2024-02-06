<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/App_Master.Master" AutoEventWireup="true" CodeBehind="UserMgmt.aspx.cs" Inherits="UFS_Application.Forms.UserMgmt" %>

<%@ Register Src="~/Forms/UserControl/UCUserManagement.ascx" TagPrefix="uc1" TagName="UCUserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCUserManagement runat="server" ID="UCUserManagement" />
</asp:Content>
