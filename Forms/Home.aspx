<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/App_Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UFS_Application.Forms.Home" %>

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
     
      
        <div class="col-12" style="font-family:Verdana; font-size: 25px; text-align:center">
             <br />  <br /> <b>Kaizen
            </b>
        </div>


 
    <div class="row">
        <br />
        <br />
    </div>
    <div class="row">
        <asp:Repeater ID="rptrChart" runat="server">
            <ItemTemplate>

                <div class="mt-4    col-sm-12 col-md-6  col-lg-4 ">
                    <div class="row content" style="border: 1px solid black; margin: 1px;">
                        <div class="col-12 head">
                            <br />
                        </div>
                        <div class="col-12 head" style="text-align: center">

                            <%# Eval("Categorization") %>
                        </div>
                        <div class="col-12">
                            <hr />
                        </div>
                        <div class="col-6">Min GSV </div>
                        <div class="col-6">
                            <%# String.Format("{0:n0}",Math.Round(Convert.ToDecimal(Eval("MINGSV")))) %>
                        </div>

                        <div class="col-6">Max GSV </div>
                        <div class="col-6">
                            <%# String.Format("{0:n0}",Math.Round(Convert.ToDecimal(Eval("MaxGSV")))) %>
                        </div>

                        <div class="col-6">Min TTS </div>
                        <div class="col-6">
                            <%# String.Format("{0:n0}",Math.Round(Convert.ToDecimal(Eval("MinTTS")))) %>
                        </div>

                        <div class="col-6">Max TTS </div>
                        <div class="col-6">
                            <%# String.Format("{0:n0}",Math.Round(Convert.ToDecimal(Eval("MaxTTS")))) %>
                        </div>

                        <div class="col-6">No of Contracts</div>
                        <div class="col-6">
                            <%# String.Format("{0:n0}",Math.Round(Convert.ToDecimal(Eval("NoOfContract")))) %>
                        </div>
                        <div class="col-12">
                            <br />
                        </div>

                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
