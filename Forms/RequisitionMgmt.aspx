<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/App_Master.Master" AutoEventWireup="true" CodeBehind="RequisitionMgmt.aspx.cs" Inherits="UFS_Application.Forms.RequisitionMgmt" %>

<%@ Register Src="~/Forms/UserControl/UCRequisitionMgmt.ascx" TagPrefix="uc1" TagName="UCRequisitionMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCRequisitionMgmt runat="server" id="UCRequisitionMgmt" />

    
</asp:Content>
