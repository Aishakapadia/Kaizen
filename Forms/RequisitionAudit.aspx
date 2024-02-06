<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionAudit.aspx.cs" Inherits="UFS_Application.Forms.RequisitionAudit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gv_ReqAudit" runat="server" AutoGenerateColumns="false"
                HorizontalAlign="Center" Width="100%" CssClass="mydatagrid"
                RowStyle-CssClass="rows" HeaderStyle-CssClass="header"
                >
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            RequisitionId
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("RequisitionId") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <HeaderTemplate>
                            Customer Name	
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Customer_Name	") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            Geography
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("GEOGRAPHY") %>
                        </ItemTemplate>
                    </asp:TemplateField>


                     <asp:TemplateField>
                        <HeaderTemplate>
                            User Process	
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("UserProcess") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <HeaderTemplate>
                            Approval Status	
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("ApprovalStatus	") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField>
                        <HeaderTemplate>
                            Date	
                        </HeaderTemplate>
                        <ItemTemplate>
                               <%# Eval("Created_date", "{0:MM/dd/yyyy}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField>
                        <HeaderTemplate>
                           Comments
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Comments	") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                   
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
