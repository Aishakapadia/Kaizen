<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/App_Master.Master" AutoEventWireup="true" CodeBehind="ReportMgmt.aspx.cs" Inherits="UFS_Application.Forms.ReportMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .head {
            background-color: #31708f;
            color: white;
        }
        .content {
            background-color: #31708f;
            font-family: "Times New Roman", Times, serif;
            color: black;
        }
    </style>
    <div class="container">
        <div class="row">

            <hr />

        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lblRequisition" runat="server" CssClass="mainHeading" Text="Summary: "></asp:Label>

                <asp:LinkButton ID="lbtnSummary" runat="server" Text="Download" OnClick="lbtnSummary_Click"></asp:LinkButton>

            </div>
        </div>
        <div class="row">

            <hr />

        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label ID="Label1" runat="server" CssClass="mainHeading" Text="By SKU:  "></asp:Label>

                <asp:LinkButton ID="lbtnBySK" runat="server" Text="Download" OnClick="lbtnBySK_Click"></asp:LinkButton>

            </div>

        </div>
        <div class="row">

            <hr />

        </div>
        <div class="row">
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" CssClass="mainHeading" Text="By Customer:  "></asp:Label>

                <asp:LinkButton ID="lbtnByCustomer" runat="server" Text="Download" OnClick="lbtnByCustomer_Click"></asp:LinkButton>

            </div>

        </div>
    </div>
</asp:Content>
