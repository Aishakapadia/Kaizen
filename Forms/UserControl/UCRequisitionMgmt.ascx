<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequisitionMgmt.ascx.cs" Inherits="UFS_Application.Forms.UserControl.UCRequisitionMgmt" %>
<div class="container">
    <style>
        .MarginRight {
            margin-right: 5px;
            font-size: 13px;
        }
    </style>

    <hr />
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblRequisition" runat="server" CssClass="mainHeading" Text="Requisition Management"></asp:Label>
            <br />
        </div>
    </div>

    <div class="row">
        <div class="col-2">

            <asp:Label ID="lblRequisitionSTatus" runat="server" Text=" (New)" Font-Bold="True" ForeColor="#009900"></asp:Label>
            <br />
            <asp:Label ID="Label28" runat="server" Text="Requisition Id:" CssClass="Label"></asp:Label>
        </div>
        <div class="col-4">
            <br />
            <asp:Label ID="lblRequisitionId" runat="server" Text="" Visible="true"></asp:Label>
        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label9" runat="server" Text="Company Code:" CssClass="Label"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlCompanyCode" CssClass="ddlwidth350  chosen-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompanyCode_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator3" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="ddlCompanyCode"
                ErrorMessage="Please select company code"></asp:RequiredFieldValidator>
        </div>

        <div class="col-2">
            <asp:Label ID="Label1" runat="server" Text="Customer Name:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="50" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation"
                ErrorMessage="Please enter Customer name" ControlToValidate="txtCustomerName" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label2" runat="server" Text="Function:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlFunction" CssClass="ddlwidth350  chosen-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="ddlFunction"
                ErrorMessage="Please select function"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label27" runat="server" Text="Customer:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:RadioButtonList ID="rblCustomer" CssClass="MarginRight" runat="server" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="3" Width="300px">
                <asp:ListItem Value="NEW" Text="NEW" Selected="True"></asp:ListItem>
                <asp:ListItem Value="EXISTING" Text="EXISTING"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="txtExistingGM" runat="server" placeholder="Existing GM" ClientIDMode="Static" MaxLength="49" CssClass="textBox width350 " Text=""></asp:TextBox>

        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label4" runat="server" Text="Geography:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlGeography" CssClass="ddlwidth350  chosen-select" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="ddlGeography"
                ErrorMessage="Please select geography"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label3" runat="server" Text="Pop Codes:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:ListBox ID="lvPopCode" CssClass="ddlwidth350  chosen-select" SelectionMode="Multiple" runat="server" ClientIDMode="Static"></asp:ListBox>

        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label8" runat="server" Text="Time Period(From): "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtTimePeriodFrom" runat="server" ClientIDMode="Static" CssClass="textBox width350 calendar" Text=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJobFrom" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="txtTimePeriodFrom"
                ErrorMessage="Please enter from date"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label5" runat="server" Text="Time Period(To): "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtTimePeriodTo" runat="server" ClientIDMode="Static" CssClass="textBox width350 calendar" Text=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="txtTimePeriodTo"
                ErrorMessage="Please enter to date"></asp:RequiredFieldValidator>
        </div>




    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label14" runat="server" Text="Brands Used By customer:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtBrandUsedCustomer" runat="server" TextMode="MultiLine" CssClass="textBox width350 height70"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="validation" TextMode="MultiLine"
                ErrorMessage="Please enter brand used customer" ControlToValidate="txtBrandUsedCustomer" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="col-2">
            <asp:Label ID="Label6" runat="server" Text="Customer Background:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtCustomerBackground" runat="server" TextMode="MultiLine" CssClass="textBox width350 height70"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="validation"
                ErrorMessage="Please enter Customer background" ControlToValidate="txtCustomerBackground" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <%--    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label10" runat="server" Text="Table header:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:ListBox ID="lvSkuDetail" CssClass="ddlwidth350  chosen-select" SelectionMode="Multiple"  runat="server" ClientIDMode="Static"></asp:ListBox>
        </div>
        <div class="col-2">
            <asp:Label ID="Label11" runat="server" Text="Product Name:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlProductName" CssClass="ddlwidth350 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator8" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGRequisition" runat="server" ControlToValidate="ddlProductName"
                ErrorMessage="Please select ddlProduct Name"></asp:RequiredFieldValidator>
        </div>
    </div>--%>
    <%-- <div class="row">
        <div class="col-2">
            <asp:Label ID="Label12" runat="server" Text="SKU Code:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtSKUCode" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="validation"
                ErrorMessage="Please enter SKU Code" ControlToValidate="txtSKUCode" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label13" runat="server" Text="Discount Percentage:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtDiscountPercentage" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="validation"
                ErrorMessage="Please enter discount percentage" ControlToValidate="txtDiscountPercentage" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>--%>
    <%-- <div class="row">
        <div class="col-2">
            <asp:Label ID="Label15" runat="server" Text="Min Qty/Month cases:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMinQtyMonthCases" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="validation"
                ErrorMessage="Please enter min qty month case" ControlToValidate="txtMinQtyMonthCases" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label16" runat="server" Text="Max Qty/Month cases:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMaxQtyMonthCases" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="validation"
                ErrorMessage="Please enter max qty month case" ControlToValidate="txtMaxQtyMonthCases" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>--%>


    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label19" runat="server" Text="GM %:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtGM" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" CssClass="validation"
                ErrorMessage="Please enter GM" ControlToValidate="txtGM" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rvGM" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtGM"></asp:RegularExpressionValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label7" runat="server" Text="Promotion Description and Objective:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtPromotionDescriptionandObjective" runat="server" CssClass="textBox width350 "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="validation"
                ErrorMessage="Please enter Promotion Description and Objective" ControlToValidate="txtPromotionDescriptionandObjective" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>


    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label20" runat="server" Text="Min GSV(PKR):"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMinGSV" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" CssClass="validation"
                ErrorMessage="Please enter Min GSV(PKR)" ControlToValidate="txtMinGSV" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rvMinGSV" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtMinGSV"></asp:RegularExpressionValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label21" runat="server" Text="Max GSV(PKR):"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMaxGSV" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" CssClass="validation"
                ErrorMessage="Please enter Max GSV(PKR)" ControlToValidate="txtMaxGSV" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rvMaxGSV" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtMaxGSV"></asp:RegularExpressionValidator>
        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label22" runat="server" Text="Min TTS(PKR):"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMinTTS" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" CssClass="validation"
                ErrorMessage="Please enter Min TTS(PKR)" ControlToValidate="txtMinTTS" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rv3" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtMinTTS"></asp:RegularExpressionValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label23" runat="server" Text="Max TTS(PKR):"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtMaxTTS" runat="server" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" CssClass="validation"
                ErrorMessage="Please enter Max TTS(PKR)" ControlToValidate="txtMaxTTS" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev2" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtMaxTTS">
            </asp:RegularExpressionValidator>
        </div>

    </div>

    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label18" runat="server" Text="ROI %:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtROI" runat="server" MaxLength="11" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="validation"
                ErrorMessage="Please enter ROI" ControlToValidate="txtROI" ValidationGroup="VGRequisition"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="NumberRegex" runat="server" ValidationGroup="VGRequisition" CssClass="validation"
                ErrorMessage="Invalid number" Display="Dynamic" ValidationExpression="^\d*\.{0,1}\d+$"
                ControlToValidate="txtROI">
            </asp:RegularExpressionValidator>

        </div>
        <div class="col-2">
            <asp:Label ID="Label17" runat="server" Visible="false" Text="Total:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:Label ID="lblTotal" runat="server" Visible="false" Text="0"></asp:Label>

        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label24" runat="server" Text="Comments:"></asp:Label>
        </div>
        <div class="col-10">
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="textBox width80p height70"></asp:TextBox>
        </div>

    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>
    <div id="d_FileUpload" runat="server" visible="false">
        <div class="row">
            <div class="col-12">
                <asp:Label ID="Label25" runat="server" Text="Attachments:"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:Label ID="lblFileUpload" runat="server" Text="File Upload: "></asp:Label>

                <asp:FileUpload ID="fupRequisition" ClientIDMode="Static" runat="server" ValidationGroup="vgFileUpload" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="validation"
                    ErrorMessage="Please Select file" ControlToValidate="fupRequisition" ValidationGroup="vgFileUpload"
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnUpload" runat="server" ValidationGroup="vgFileUpload" Text="Upload"
                    OnClientClick="return FilOnClientClickeUploadSize();" OnClick="btnUpload_Click" />
            </div>
            <div class="col-10" style="border: 1px;">
                <div class="row" style="border: 1px;">

                    <asp:Repeater ID="RpAttachment" runat="server" OnItemCommand="RpAttachment_ItemCommand">
                        <ItemTemplate>
                            <div class="col-6" style="text-align: right;">
                                (  <%# Eval("User.UserName") %> ) - 
                        <asp:LinkButton ID="lbtnDownload" runat="server" CommandArgument='<%# Bind("RequisitionAttachementId") %>' CommandName="DOWNLOAD" Text='<%# Eval("fileName") %>'></asp:LinkButton>
                                &nbsp&nbsp&nbsp&nbsp
                        <asp:ImageButton ID="ibtnDelete_FileUpload" runat="server" CausesValidation="false" ForeColor="Black" ImageUrl="~/Images/delete.png" Width="20px"
                            CommandArgument='<%# Bind("RequisitionAttachementId") %>' CommandName="GRIDDELETE"
                            Visible='<%#((UFS_Application.App_class.UserSession) Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]).userid.ToString()
                                    ==  Convert.ToString(Eval("CreatedBy"))
                                    ? true:false %>'
                            ToolTip="Delete" CssClass="padding5 "
                            OnClientClick="return confirm('Do you want to delete this record?');"></asp:ImageButton>
                            </div>
                        </ItemTemplate>



                    </asp:Repeater>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label ID="Label10" runat="server" Text="SKU Details:"></asp:Label>
        </div>
    </div>
    <div class="row">


        <div class="col-12">
            <div class="col-12" style="overflow-x: scroll; max-height: 200px;" align="center">
                <asp:GridView ID="gvProductDetail" AutoGenerateColumns="false" HorizontalAlign="Center" Height="100px" Width="99%" CssClass="mydatagrid"
                    runat="server" RowStyle-CssClass="rows" HeaderStyle-CssClass="header"
                    OnRowCommand="gvProductDetail_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                RequisitionDetailId
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("RequisitionDetailId") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Product Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("ProductName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                SKU Code
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("SKUCode") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Discount %
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Discount") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Min Qty/Month Cases
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("MinQtyMonthCases") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Max Qty/Month Cases
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("MaxQtyMonthCases") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:LinkButton ID="ibtnDelete" runat="server" CausesValidation="false" ForeColor="Black"
                                    CommandArgument='<%# Bind("RequisitionDetailId") %>' CommandName="GRIDDELETE"
                                    ToolTip="Delete" CssClass=" ">Delete</asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
            <div class="row" id="div_total" runat="server" visible="false">
                <div class="col-8">
                </div>
                <div class="col-2">
                    Min.Qty/Month cases(Total): 
                    <asp:Label ID="lblMinQtyMonthCases" runat="server"></asp:Label>

                </div>
                <div class="col-2">
                    Max.Qty/Month cases(Total): 
                    <asp:Label ID="lblMaxQtyMonthCases" runat="server"></asp:Label>
                </div>

            </div>


        </div>

    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label11" runat="server" Text="Product Name:"></asp:Label>
            <%-- <asp:TextBox ID="txtProductName" runat="server" ValidationGroup="VGRequisitionDetail" CssClass="textBox width250"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="validation"
                ErrorMessage="Please enter product name" ControlToValidate="txtProductName" ValidationGroup="VGRequisitionDetail"
                Display="Dynamic"></asp:RequiredFieldValidator>--%>


            <asp:DropDownList ID="ddlProductName" CssClass="chosen-select" Style="width: 275px;" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator10" Display="Dynamic" CssClass="validation"
                runat="server" ControlToValidate="ddlProductName" ValidationGroup="VGRequisitionDetail"
                ErrorMessage="Please select product name"></asp:RequiredFieldValidator>



        </div>
        <div class="col-2">
            <asp:Label ID="Label12" runat="server" Text="SKU Code:"></asp:Label>
            <asp:TextBox ID="txtSKUCode" runat="server" ValidationGroup="VGRequisitionDetail" Enabled="false" CssClass="textBox width150"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="validation"
                ErrorMessage="Please enter Sku code" ControlToValidate="txtSKUCode" ValidationGroup="VGRequisitionDetail"
                Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
        <div class="col-2">
            <asp:Label ID="Label13" runat="server" Text="Discount %:"></asp:Label>
            <%--  <asp:TextBox ID="txtDiscount" runat="server" CssClass="textBox width150"></asp:TextBox>--%>
            <input id="txtDiscount_2" type="number" min="0" max="99" runat="server" class="width150" value="0" />

        </div>
        <div class="col-2">
            <asp:Label ID="Label15" runat="server" Text="Min.Qty/Month cases:"></asp:Label>
            <%-- <asp:TextBox ID="txtMinQtyCases" runat="server" CssClass="textBox width150"></asp:TextBox>--%>
            <input id="txtMinQtyCases_2" type="number" min="0" runat="server" class=" width150" value="0" />

        </div>
        <div class="col-3">
            <asp:Label ID="Label16" runat="server" Text="Max.Qty/Month cases:"></asp:Label>
            <%--<asp:TextBox ID="txtMaxQtyCases" runat="server" CssClass="textBox width150"></asp:TextBox>--%>
            <input id="txtMaxQtyCases_2" type="number" min="0" runat="server" class=" width150" value="0" />

            <asp:Button ID="btnAdd_Detail" runat="server" ValidationGroup="VGRequisitionDetail" Text="Add" ToolTip="Add" CssClass="button width100 height35" OnClick="btnAdd_Detail_Click" />

        </div>
    </div>
    <div class="row" id="div_status" runat="server" visible="false">

        <div class="col-2">
            <asp:Label ID="Label26" runat="server" Text="Comments"></asp:Label>
        </div>
        <div class="col-10">
            <asp:TextBox ID="txtApprovalRejectionTerminationComments" runat="server" TextMode="MultiLine" CssClass="textBox width80p height70"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>


    <div class="row">
        <div class="col-3">

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" Visible="false" CssClass="button width260 height35" OnClick="btnSubmit_Click" />
        </div>
        <div class="col-3">
            <asp:Button ID="btnAddNewRequest" runat="server" ValidationGroup="VGRequisition" Visible="false" Text="Add Existing Requisition" ToolTip="Add Existing Requisition" CssClass="button width260 height35" OnClick="btnAddNewRequest_Click" />
            <asp:Button ID="btnApprove" runat="server" Text="Approve" ToolTip="Approve" Visible="false" CssClass="button width260 height35" OnClick="btnApprove_Click" />
            <asp:Button ID="btnTerminateApprove" runat="server" Text="Termination Approve" ToolTip="Termination Approve" Visible="false" CssClass="button width260 height35" OnClick="btnTerminateApprove_Click" />
        </div>
        <div class="col-3">
            <asp:Button ID="btnAdd" runat="server" ValidationGroup="VGRequisition" Text="Add" ToolTip="Add" CssClass="button width260 height35" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="VGRequisition" Text="Save" ToolTip="Save" CssClass="button width260 height35" Visible="false" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnUpdatePopCode" runat="server" ValidationGroup="VGRequisition" Text="Update Pop Code" ToolTip="Update Pop Code" CssClass="button width260 height35" Visible="false" OnClick="btnUpdatePopCode_Click" />
            <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="Reject" Visible="false" CssClass="button width260 height35" OnClick="btnReject_Click" />
            <asp:Button ID="btnTerminate" runat="server" Text="Terminate" ToolTip="Terminate" Visible="false" CssClass="button width260 height35" OnClick="btnTerminate_Click" />
            <asp:Button ID="btnTerminateReject" runat="server" Text="Termination Reject" ToolTip="Termination Reject" Visible="false" CssClass="button width260 height35" OnClick="btnTerminateReject_Click" />

        </div>
        <div class="col-3">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button width260 height35" OnClick="btnCancel_Click" />

            <%--  <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" CssClass="button width260 height35" />--%>
        </div>

    </div>
    <br />
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:DropDownList ID="ddlFilter" runat="server" CssClass="ddlwidth350  chosen-select" AutoPostBack="True" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Button ID="btnBulkApproved" runat="server" Text="Approve Selected" CssClass="button width260 height35"
                OnClientClick="return confirm('Do you want to approved all selected records?')"
                OnClick="btnBulkApproved_Click" />
            <asp:Button ID="btnBulkDecline" runat="server" Text="Reject Selected" CssClass="button width260 height35"
                OnClientClick="return confirm('Do you want to reject all selected records?')"
                OnClick="btnBulkDecline_Click" />

        </div>
    </div>

    <div class="row">

        <div class="col-12" style="overflow-x: scroll; overflow-y: scroll; max-height: 350px;" align="center">
            <asp:GridView ID="gvRequisition" AutoGenerateColumns="false" runat="server"
                AllowPaging="true" PageSize="20" HorizontalAlign="Center" Width="99%" CssClass="mydatagrid"
                PagerStyle-CssClass="pager" RowStyle-CssClass="rows"
                HeaderStyle-CssClass="header" EmptyDataText="No requisition exists"
                OnRowCommand="gvRequisition_RowCommand" OnPageIndexChanging="gvRequisition_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                     &nbsp;   <asp:CheckBox ID="chboxSelectHead" runat="server" AutoPostBack="true" OnCheckedChanged="chboxSelectHead_CheckedChanged"  />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chboxSelectItem" ToolTip='<%# Bind("RequisitionId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnViewAudit" runat="server" Text="Audit" CausesValidation="false" ClientIDMode="Static" ForeColor="Black"
                                ToolTip='<%# Bind("RequisitionId") %>' CommandName="AUDIT" OnClientClick="return OpenPageInDialogue('RequisitionAudit.aspx', this);">


                            </asp:LinkButton>

                            <asp:LinkButton ID="btnAction" runat="server" CausesValidation="false" ForeColor="Black"
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDACTION"
                                Visible='<%# Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]!=null
                                    &&
                                ((UFS_Application.App_class.UserSession) Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]).AccountLevel>
                                    Convert.ToInt32(UFS_Application.App_class.MisOp.AccountTypes.AM)  %>'
                                ToolTip="Edit" CssClass=" ">Action</asp:LinkButton>
                            <asp:LinkButton ID="ibtnView" runat="server" CausesValidation="false" ForeColor="Black"
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDVIEW"
                                ToolTip="Edit" CssClass=" ">View</asp:LinkButton>

                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" ForeColor="Black"
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDREJECT"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="2"
                                    &&
                                    ((UFS_Application.App_class.UserSession) Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]).userid.ToString()
                                    ==  Convert.ToString(Eval("CreatedBy"))
                                    ? true:false %>'
                                ToolTip="view detail" CssClass=" ">Rejected</asp:LinkButton>

                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" ForeColor="Black"
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDAPPROVED"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="3"
                                    &&
                                    ((UFS_Application.App_class.UserSession) Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]).userid.ToString()
                                    ==  Convert.ToString(Eval("CreatedBy"))
                                    ? true:false %>'
                                ToolTip="(Update Pop Code)" CssClass=" ">Approved</asp:LinkButton>

                            <asp:Image ID="imgApproved" runat="server"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="3" ? true:false %>'
                                ImageUrl="~/Images/Approved.png" Width="50px" />
                            <asp:Image ID="Image1" runat="server"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="4" ? true:false %>'
                                ImageUrl="~/Images/Terminated.png" Width="50px" />




                            <asp:LinkButton ID="ibtnEdit" runat="server" CausesValidation="false" ForeColor="Black"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="0"? true:false %>'
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDEDIT"
                                ToolTip="Edit" CssClass=" ">Edit</asp:LinkButton>

                            <asp:LinkButton ID="ibtnDelete" runat="server" CausesValidation="false" ForeColor="Black"
                                CommandArgument='<%# Bind("RequisitionId") %>' CommandName="GRIDDELETE"
                                Visible='<%# Convert.ToString(Eval("RequisitionStatus"))=="0"
                                    &&
                                    ((UFS_Application.App_class.UserSession) Session[UFS_Application.App_class.MisOp.SessionNames.S_User.ToString()]).userid.ToString()
                                    ==  Convert.ToString(Eval("CreatedBy"))
                                    ? true:false %>'
                                ToolTip="Delete" CssClass=" "
                                OnClientClick="return confirm('Do you want to delete this record?');">Delete</asp:LinkButton>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Requisition Id
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("RequisitionId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--   <asp:TemplateField>
                    <HeaderTemplate>
                        CompanyId
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("CompanyId") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Created By
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("User.UserName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Company Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Company.CompanyName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Customer Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("CustomerName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--    <asp:TemplateField>
                    <HeaderTemplate>
                        FunctionId
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("FunctionId") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Function Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Function.FunctionName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Geography
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Geography") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            From Time
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("FromTime", "{0:MM/dd/yyyy}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            To Time
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("ToTime", "{0:MM/dd/yyyy}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                        <HeaderTemplate>
                            Customer Background
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("CustomerBackground") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Brand User Customer
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("BrandUserCustomer") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Promotion Desc
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("PromotionDesc") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            Promotion Desc
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("PromotionDesc") %>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <HeaderTemplate>
                            Total
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Total") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            ROI
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("ROI") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            GM
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("GM") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Min GSV
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("MinGSV") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Max GSV
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("MaxGSV") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Min TTS
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("MinTTS") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Max TTS
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("MaxTTS") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Comments
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Comments") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>

            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
        </div>
    </div>
    <div class="row">
        <div class="col-12">
        </div>
    </div>
</div>
<br />
