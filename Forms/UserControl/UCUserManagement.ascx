<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUserManagement.ascx.cs" Inherits="UFS_Application.Forms.UserControl.UCUserManagement" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblUser" runat="server" CssClass="mainHeading" Font-Bold="True" ForeColor="#009900" Text="User Management"></asp:Label>
            <%--  <asp:Label ID="lblUserSTatus" runat="server" Text="New" Font-Bold="True" ForeColor="#009900"></asp:Label>--%>
            <asp:Label ID="lblUserId" runat="server" Text="" Visible="false"></asp:Label>

        </div>

    </div>
    <br />
    <div class="row">

        <div class="col-2">
            <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation"
                ErrorMessage="Please enter user name" ControlToValidate="txtUserName" ValidationGroup="VGUser"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">

        <div class="col-2">
            <asp:Label ID="Label2" runat="server" Text="User Email:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validation"
                ErrorMessage="Please enter Eamil address" ControlToValidate="txtEmail" ValidationGroup="VGUser"
                Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="VGUser" CssClass="validation"
                Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email address"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>

    <div class="row">

        <div class="col-2">
            <asp:Label ID="Label3" runat="server" Text="Account Type:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlAccountTyps" CssClass="ddlwidth350  chosen-select" runat="server">
            </asp:DropDownList>

        </div>
    </div>


    <div class="row">

        <div class="col-2">
            <asp:Label ID="Label4" runat="server" Text="First Name:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validation"
                ErrorMessage="Please enter first name" ControlToValidate="txtFirstName" ValidationGroup="VGUser"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">

        <div class="col-2">
            <asp:Label ID="Label5" runat="server" Text="Last Name:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" CssClass="textBox width350"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validation"
                ErrorMessage="Please enter last name" ControlToValidate="txtLastName" ValidationGroup="VGUser"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>


    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label6" runat="server" Text="Region:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlRegion" CssClass="ddlwidth350  chosen-select" runat="server">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label7" runat="server" Text="Active:"></asp:Label>
        </div>
        <div class="col-4">
            <asp:CheckBox ID="chbActive" runat="server" />
        </div>

    </div>

    <div class="row">
        <br />
        <br />
    </div>

    <div class="row padding11">
        <div class="col-12">
            <asp:Button ID="btnAdd" runat="server" ValidationGroup="VGUser" Text="Add" ToolTip="Add" CssClass="button width260 height35" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="VGUser" Text="Update" ToolTip="Update" Visible="false" CssClass="button width260 height35" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" ToolTip="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />


        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-12">

            <div class="col-12" style="overflow-x: scroll; max-height: 350px;" align="center">
                <asp:GridView ID="gvUserMgmt" AutoGenerateColumns="false" HorizontalAlign="Center" 
                    Height="100px" Width="99%" CssClass="mydatagrid"
                    runat="server" RowStyle-CssClass="rows" HeaderStyle-CssClass="header"
                     OnRowCommand="gvUserMgmt_RowCommand">
                    <Columns>

                        <asp:TemplateField>

                            <ItemTemplate>

                                <%--<asp:Button ID="ImageButton2" Width="70px" ForeColor="Red" runat="server" CommandName="GRIDINACTIVATE" CausesValidation="false"
                                    Visible='<%# Convert.ToString(Eval("IsActive"))=="True"? false: true %>'
                                    CommandArgument='<% #Eval("UserId") %>' Text="In-Active" />
                                <asp:Button ID="LinkButton1" Width="70px" ForeColor="Green" runat="server" CommandName="GRIDACTIVATE" CausesValidation="false"
                                    Visible='<%# Convert.ToString(Eval("IsActive"))=="False"?  false: true %>'
                                    CommandArgument='<% #Eval("UserId") %>' Text="Active" />
                                <asp:Button ID="Button1" Width="70px" runat="server" CommandName="GRIDVIEW" CausesValidation="false"
                                    CommandArgument='<% #Eval("UserId") %>' Text="View" />--%>
                                <asp:Button ID="Button2" Width="70px" runat="server" CommandName="GRIDEDIT" CausesValidation="false"
                                    CommandArgument='<% #Eval("UserId") %>' Text="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <HeaderTemplate>
                                UserId
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("UserId") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                UserName
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("UserName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Email
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("EmailAddress") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Account Type
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("AccountType.AccountTitle") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                First Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FirstName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Last Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("LastName") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <HeaderTemplate>
                                Region
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Region.RegionName") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                IsActive
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Convert.ToString(Eval("IsActive"))=="True"?"Activated":"De-Activated" %>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>



</div>
