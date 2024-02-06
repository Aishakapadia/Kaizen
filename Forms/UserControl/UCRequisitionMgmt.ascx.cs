using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;
using UFS_Application.BAL;
using UFS_Application.DAL;

namespace UFS_Application.Forms.UserControl
{
    public partial class UCRequisitionMgmt : System.Web.UI.UserControl
    {
        public string message = "";
        public string heading = "";
        public string type = "";
        public Requisition requisition;
        public string returnMessage = "";
        //  List<Requisition_Detail> rdList;
        List<RequisitionCls> requisitionClsList;
        public RequisitionAttachmentRepository requisitionAttachmentRepository;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                requisitionClsList = new List<RequisitionCls>();
                LoadControl();
                ViewState["RequisitionDetail"] = requisitionClsList;
                ViewState["IsRequisitionDetailModified"] = false;
            }

        }
        public void RoleImplementation()
        {
            var userObj = new SessionHelper().getUserSession();
            if (userObj != null)
            {
                if (userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.AM) || userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.TM))
                {
                    btnAdd.Visible = true;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnTerminate.Visible = false;
                    btnAdd_Detail.Visible = true;
                }
                else if (userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.GSM))
                {
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnTerminate.Visible = false;
                    btnAdd_Detail.Visible = false;
                }
                else if (userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.FBP))
                {
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnTerminate.Visible = false;
                    btnAdd_Detail.Visible = false;
                }
                else if (userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.MF))
                {
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnTerminate.Visible = false;
                    btnAdd_Detail.Visible = false;
                }
                else if (userObj.AccountLevel == Convert.ToInt32(MisOp.AccountTypes.CH))
                {
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnUpdate.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    btnTerminate.Visible = false;
                    btnAdd_Detail.Visible = false;
                }
            }

        }
        public void LoadControl()
        {

            GetGridViewFilter();
            GetAllRequisition(new SessionHelper().getUserSession().userid);
            GetAllCompanyCode();
            GetAllFunction();
            GetAllGeography();
            GetAllProductName();
            GetAllPopCode();
            GetSku_Detrails();
            txtTimePeriodFrom.Text = HelperFunction.Dateformat(DateTime.Now);
            txtTimePeriodTo.Text = HelperFunction.Dateformat(DateTime.Now);
            RoleImplementation();
            if (new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(MisOp.AccountTypes.AM) ||
                new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(MisOp.AccountTypes.TM))
            {
                ddlFilter.Visible = true;
            }
            else
            {
                ddlFilter.Visible = false;
            }


        }

        public void GetGridViewFilter()
        {
            new MiscellaneousOperation().GetGridViewFilter(ref ddlFilter);
        }
        public void GetAllRequisition(int userid)
        {
            int accounTypeIdForBulkOperation = 5;
            int currentfiltervalue = Convert.ToInt32(ddlFilter.SelectedValue);
            var result = new RequisitionRepository().GetAllRequisition(userid, currentfiltervalue);

            gvRequisition.DataSource = result;
            gvRequisition.DataBind();
            if (new SessionHelper().getUserSession().AccountTyeId >= accounTypeIdForBulkOperation && result.Count > 0)
            {
                gvRequisition.Columns[0].Visible = true;
                btnBulkApproved.Visible = true;
                btnBulkDecline.Visible = true;
            }
            else
            {
                gvRequisition.Columns[0].Visible = false;
                btnBulkApproved.Visible = false;
                btnBulkDecline.Visible = false;
            }
        }
        public void GetAllCompanyCode()
        {
            new MiscellaneousOperation().fillCompanies(ref ddlCompanyCode);
        }

        public void GetAllFunction()
        {
            new MiscellaneousOperation().fillFunction(ref ddlFunction);
        }
        public void GetAllGeography()
        {
            new MiscellaneousOperation().fillGeography(ref ddlGeography);
        }
        public void GetAllProductName()
        {
            new MiscellaneousOperation().GetAllProductName(ref ddlProductName);

        }
        public void GetAllPopCode()
        {
            OracleExtract oracleExtract = new OracleExtract();
            var lstPopCode = oracleExtract.GetPopCodes();
            lvPopCode.DataSource = lstPopCode;
            lvPopCode.DataTextField = "PopCodeName";
            lvPopCode.DataValueField = "PopCodeId";
            lvPopCode.DataBind();

        }
        public void GetSku_Detrails()
        {
            //OracleExtract oracleExtract = new OracleExtract();
            //var lstPopCode = oracleExtract.GetSku_Detrails();
            //lvSkuDetail.DataSource = lstPopCode;
            //lvSkuDetail.DataTextField = "Sku_DetrailName";
            //lvSkuDetail.DataValueField = "Sku_DetrailId";
            //lvSkuDetail.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime fromVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (fromVal > toVal)
            {
                heading = "Add Requisition "; type = "error";
                message = "The from date can not be greater than to date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }
            if (gvProductDetail.Rows.Count == 0)
            {
                heading = "Add Requisition "; type = "error";
                message = "Atleast one detail record is required.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;

            }

            requisition = new Requisition();
            requisition = FormToObjectRequisition();
            bool result = new RequisitionRepository().SaveRequisition(requisition, ref returnMessage);
            if (result)
            {
                GetAllRequisition(new SessionHelper().getUserSession().userid);
                heading = "Requisition Added";
                message = "The Requisition has been added.";
                type = "success";
                FormReset();
                requisitionClsList = new List<RequisitionCls>();
                ViewState["RequisitionDetail"] = requisitionClsList;
                FormStatus(MisOp.FormStatus.ADD);
                FillgvProductDetail();
            }
            else
            {
                heading = "Add Requisition ";
                message = returnMessage;
                type = "error";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);

        }
        public Requisition FormToObjectRequisition()
        {
            requisition = new Requisition();
            if (lblRequisitionId.Text != "")
            {
                requisition.RequisitionId = Convert.ToInt32(lblRequisitionId.Text);
                requisition.LastModifiedBy = new SessionHelper().getUserSession().userid;
                requisition.LastModifiedDate = DateTime.Now;
            }
            else
            {
                requisition.CreatedBy = new SessionHelper().getUserSession().userid;
                requisition.CreatedDate = DateTime.Now;
            }
            requisition.BrandUserCustomer = txtBrandUsedCustomer.Text;
            requisition.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
            requisition.CustomerName = txtCustomerName.Text;
            requisition.FunctionId = Convert.ToInt32(ddlFunction.SelectedValue);
            requisition.Geography = ddlGeography.SelectedValue.ToString();
            requisition.FromTime = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            requisition.ToTime = DateTime.ParseExact(txtTimePeriodTo.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            requisition.PromotionDesc = txtPromotionDescriptionandObjective.Text;
            requisition.BrandUserCustomer = txtBrandUsedCustomer.Text;
            requisition.CustomerBackground = txtCustomerBackground.Text;
            requisition.GM = Convert.ToDecimal(txtGM.Text);
            requisition.MinGSV = Convert.ToDecimal(txtMinGSV.Text);
            requisition.MaxGSV = Convert.ToDecimal(txtMaxGSV.Text);
            requisition.MinTTS = Convert.ToDecimal(txtMinTTS.Text);
            requisition.MaxTTS = Convert.ToDecimal(txtMaxTTS.Text);
            requisition.ROI = Convert.ToDecimal(txtROI.Text);
            requisition.Comments = txtComments.Text;
            requisition.RequisitionStatus = 0;
            int number = 0;
            Int32.TryParse(lblTotal.Text, out number);
            requisition.Total = number;
            requisition.IsActive = true;
            requisition.IsTerminationRequested = false;
            requisition.IsNewUser = rblCustomer.SelectedValue == "NEW" ? true : false;
            requisition.ExistingGM = txtExistingGM.Text;
            //====================add requisition Detail
            if (ViewState["RequisitionDetail"] != null)
            {
                requisitionClsList = (List<RequisitionCls>)ViewState["RequisitionDetail"];

                foreach (var item in requisitionClsList)
                {
                    requisition.Requisition_Detail.Add(new Requisition_Detail()
                    {
                        Discount = item.Discount,
                        IsActive = true,
                        ProductName = item.ProductName,
                        SKUCode = item.SKUCode,
                        MaxQtyMonthCases = item.MaxQtyMonthCases,
                        MinQtyMonthCases = item.MinQtyMonthCases
                    });
                }

            }

            //===========================Get All POP Code
            var query = lvPopCode.Items.Cast<ListItem>().Where(item => item.Selected);
            List<RequisitionPopCode> rPCLst = new List<RequisitionPopCode>();
            foreach (ListItem item in query)
            {
                rPCLst.Add(new RequisitionPopCode() { IsActive = true, PopCode = item.Text });
            }
            requisition.RequisitionPopCodes = rPCLst;
            ////===========================Get All SKU Detail
            //var querySKU = lvSkuDetail.Items.Cast<ListItem>().Where(item => item.Selected);
            //List<RequisitionSKUDetail> rSKULst = new List<RequisitionSKUDetail>();
            //foreach (ListItem item in querySKU)
            //{
            //    rSKULst.Add(new RequisitionSKUDetail() { IsActive = true, SKUCode = item.Text });
            //}
            //requisition.RequisitionSKUDetails = rSKULst;
            return requisition;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime fromVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (fromVal > toVal)
            {
                heading = "Add Requisition "; type = "error";
                message = "The from date can not be greater than to date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }
            requisition = new Requisition();
            requisition = FormToObjectRequisition();
            bool result = new RequisitionRepository().SaveRequisition(requisition, ref returnMessage);
            if (result)
            {
                GetAllRequisition(new SessionHelper().getUserSession().userid);
                heading = "Requisition Updated";
                message = "The Requisition has been updated.";
                type = "success";
                FormReset();
                requisitionClsList = new List<RequisitionCls>();
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
            }
            else
            {
                heading = "Requisition Updated";
                message = returnMessage;
                type = "error";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FormReset(); FormStatus(MisOp.FormStatus.ADD);
        }
        public bool DeleteRequisitionByRequisitionId(int RequisitionId)
        {
            return new RequisitionRepository().DeleteRequisitionByRequisitionId(RequisitionId);
        }
        public Requisition GetRequisitionByRequisitionId(int RequisitionId)
        {
            return new RequisitionRepository().GetRequisitionByRequisitionId(RequisitionId, ref message);
        }
        protected void gvRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDDELETE.ToString())
            {
                if (DeleteRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString())))
                {
                    GetAllRequisition(new SessionHelper().getUserSession().userid);
                    FormReset(); FormStatus(MisOp.FormStatus.ADD);
                }
            }
            else if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDEDIT.ToString())
            {
                var requisitionObj = GetRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (requisitionObj != null)
                {
                    getAttachmentByRequisitionId(requisitionObj.RequisitionId);
                    ObjectToFormProject(requisitionObj); gvProductDetail.Columns[6].Visible = true;
                    btnUpdate.Visible = true;
                    btnSubmit.Visible = true;
                    btnAddNewRequest.Visible = true;
                    lblRequisitionSTatus.Text = " (Added)";
                    btnAdd_Detail.Visible = true;
                    FormStatus(MisOp.FormStatus.EDIT);
                    fillproductbycompanyid();
                }

            }
            else if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDVIEW.ToString())
            {
                var requisitionObj = GetRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (requisitionObj != null)
                {
                    getAttachmentByRequisitionId(requisitionObj.RequisitionId);
                    ObjectToFormProject(requisitionObj);

                    btnUpdate.Visible = false;
                    btnSubmit.Visible = false;
                    btnAddNewRequest.Visible = false;
                    btnAdd_Detail.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false; fillproductbycompanyid();
                    if (requisitionObj.RequisitionStatus == 0)
                    {
                        lblRequisitionSTatus.Text = " (Added)";
                    }
                    else
                    {
                        lblRequisitionSTatus.Text = " (Entered)";// " (Submitted)";
                    }
                    //=btnAddNewRequest
                    if (requisitionObj.CreatedBy == new SessionHelper().getUserSession().userid)
                    {
                        btnAddNewRequest.Visible = true;
                    }
                    else
                    {
                        btnAddNewRequest.Visible = false;
                    }
                    FormStatus(MisOp.FormStatus.VIEW);
                    RepeaterViewOnly();

                }

            }
            else if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDACTION.ToString())
            {
                var requisitionObj = GetRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (requisitionObj != null)
                {
                    getAttachmentByRequisitionId(requisitionObj.RequisitionId);
                    ObjectToFormProject(requisitionObj);
                    btnUpdate.Visible = false;
                    btnSubmit.Visible = false;
                    btnAddNewRequest.Visible = false;
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                    btnAdd_Detail.Visible = false;
                    div_status.Visible = true;
                    FormStatus(MisOp.FormStatus.ACTION);
                    RepeaterViewOnly();
                    //==========terminate 
                    btnTerminate.Visible = false;

                    int terminatedId = Convert.ToInt32(MisOp.ApprovalStatus.Terminate);
                    //btnTerminate.Visible = false;
                    if (new SessionHelper().getUserSession().AccountTye.ToUpper()
                        == MisOp.AccountTypes.FBP.ToString())
                    {

                        if (requisitionObj.RequisitionStatus == Convert.ToInt32(MisOp.ApprovalStatus.Approved))
                        {
                            btnTerminate.Visible = true;
                            //  txtApprovalRejectionTerminationComments.Enabled = false;
                            btnApprove.Visible = false;
                            btnReject.Visible = false;
                            lblRequisitionSTatus.Text = " (Approved)";
                        }

                    }
                    else if (new SessionHelper().getUserSession().AccountTye.ToUpper()
                       == MisOp.AccountTypes.MF.ToString())
                    {
                        if (requisitionObj.RequisitionStatus == Convert.ToInt32(MisOp.ApprovalStatus.Approved))
                        {
                            lblRequisitionSTatus.Text = " (Requested for Termination)";
                            btnTerminate.Visible = false;
                            txtApprovalRejectionTerminationComments.Enabled = false;
                            btnApprove.Visible = false;
                            btnReject.Visible = false;
                            btnTerminateApprove.Visible = true;
                            btnTerminateReject.Visible = true;
                        }
                        else
                        {
                            txtApprovalRejectionTerminationComments.Enabled = true;
                        }
                    }
                    else
                    {
                        // lblRequisitionSTatus.Text = " (Requested for Termination)";
                        // txtApprovalRejectionTerminationComments.Enabled = false;
                        btnTerminate.Visible = false;
                    }
                }
            }
            else if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDREJECT.ToString())
            {
                var requisitionObj = GetRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (requisitionObj != null)
                {
                    getAttachmentByRequisitionId(requisitionObj.RequisitionId);
                    ObjectToFormProject(requisitionObj);
                    btnUpdate.Visible = false;
                    btnSubmit.Visible = false;
                    btnAddNewRequest.Visible = false;
                    lblRequisitionSTatus.Text = " (Rejected)";
                    btnAdd_Detail.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    //========changes
                    FormStatus(MisOp.FormStatus.VIEW);
                    //=============end changes

                    div_status.Visible = true; RepeaterViewOnly();
                }

            }
            else if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDAPPROVED.ToString())
            {
                var requisitionObj = GetRequisitionByRequisitionId(Convert.ToInt32(e.CommandArgument.ToString()));
                if (requisitionObj != null)
                {
                    getAttachmentByRequisitionId(requisitionObj.RequisitionId);
                    ObjectToFormProject(requisitionObj);
                    btnUpdate.Visible = false;
                    btnSubmit.Visible = false;
                    btnAddNewRequest.Visible = false;
                    lblRequisitionSTatus.Text = " (Approved - Update Pop Code)";
                    btnAdd_Detail.Visible = false;
                    btnApprove.Visible = false;
                    btnReject.Visible = false;

                    FormStatus(MisOp.FormStatus.VIEW);
                    div_status.Visible = true;
                    btnUpdatePopCode.Visible = true; RepeaterViewOnly();
                }

            }

        }

        private void RepeaterViewOnly()
        {
            foreach (RepeaterItem current in RpAttachment.Items)
            {
                ImageButton imgbutton = ((ImageButton)current.FindControl("ibtnDelete_FileUpload"));
                imgbutton.Visible = false;


            }
        }

        public void ObjectToFormProject(Requisition requisition)
        {
            lblRequisitionId.Text = requisition.RequisitionId.ToString();
            lblTotal.Text = requisition.Total.ToString();
            txtBrandUsedCustomer.Text = requisition.BrandUserCustomer.ToString();
            txtComments.Text = requisition.Comments.ToString();
            txtCustomerBackground.Text = requisition.CustomerBackground.ToString();
            txtCustomerName.Text = requisition.CustomerName.ToString();
            txtGM.Text = requisition.GM.ToString();
            txtMaxGSV.Text = requisition.MaxGSV.ToString();
            txtMaxTTS.Text = requisition.MaxTTS.ToString();
            txtMinGSV.Text = requisition.MinGSV.ToString();
            txtMinTTS.Text = requisition.MinTTS.ToString();
            txtPromotionDescriptionandObjective.Text = requisition.PromotionDesc.ToString();
            txtROI.Text = requisition.ROI.ToString();
            txtTimePeriodFrom.Text = requisition.FromTime != null ? HelperFunction.Dateformat((DateTime)requisition.FromTime) : "";
            txtTimePeriodTo.Text = requisition.ToTime != null ? HelperFunction.Dateformat((DateTime)requisition.ToTime) : "";
            ddlCompanyCode.SelectedValue = requisition.CompanyId.ToString();
            ddlFunction.SelectedValue = requisition.FunctionId.ToString();
            ddlGeography.SelectedValue = requisition.Geography.ToString();
            rblCustomer.SelectedValue = requisition.IsNewUser.HasValue ? requisition.IsNewUser.Value ? "NEW" : "EXISTING" : "NEW";
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnSubmit.Visible = true;
            btnAddNewRequest.Visible = true;
            txtExistingGM.Text = requisition.ExistingGM;
            //==========Add requisition detail
            requisitionClsList = new List<RequisitionCls>();
            foreach (var item in requisition.Requisition_Detail)
            {
                requisitionClsList.Add(new RequisitionCls()
                {
                    RequisitionDetailId = item.RequisitionDetailsId,
                    ProductName = item.ProductName,
                    SKUCode = item.SKUCode,
                    MinQtyMonthCases = Convert.ToInt32(item.MinQtyMonthCases),
                    MaxQtyMonthCases = Convert.ToInt32(item.MaxQtyMonthCases),
                    Discount = Convert.ToDecimal(item.Discount)
                });
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
            }
            //=================Add comments
            if (requisition.RequisitionApprovalStatusDetails.Count > 1)
            {
                //txtApprovalRejectionTerminationComments.Text =
                //    requisition.RequisitionApprovalStatusDetails.OrderByDescending(a => a.RequisitionApprovalStatusId).ToList()[1].Comments;
            }
            else if (requisition.RequisitionApprovalStatusDetails.Count > 0)
            {
                //txtApprovalRejectionTerminationComments.Text =
                //    requisition.RequisitionApprovalStatusDetails.OrderByDescending(a => a.RequisitionApprovalStatusId).ToList()[0].Comments;
            }

            //================Set Pop code
            foreach (ListItem item in lvPopCode.Items)
            {
                var isExists = requisition.RequisitionPopCodes.Any(a => a.PopCode == item.Text);
                if (isExists)
                {
                    item.Selected = true;
                }
            }
            ////================Set SKU detail
            //foreach (ListItem item in lvSkuDetail.Items)
            //{
            //    var isExists = requisition.RequisitionSKUDetails.Any(a => a.SKUCode == item.Text);
            //    if (isExists)
            //    {
            //        item.Selected = true;
            //    }
            //}


        }
        public void FormReset()
        {
            lblRequisitionId.Text = "";
            lblTotal.Text = "";
            ddlCompanyCode.SelectedIndex = 0;
            ddlFunction.SelectedIndex = 0;
            ddlGeography.SelectedIndex = 0;
            txtBrandUsedCustomer.Text = "";
            txtComments.Text = "";
            txtCustomerBackground.Text = "";
            txtCustomerName.Text = "";
            txtGM.Text = "";
            txtMaxGSV.Text = "";
            txtMaxTTS.Text = "";
            txtMinGSV.Text = "";
            txtMinTTS.Text = "";
            txtPromotionDescriptionandObjective.Text = "";
            txtROI.Text = "";
            txtTimePeriodFrom.Text = HelperFunction.Dateformat(DateTime.Now).ToString();
            txtTimePeriodTo.Text = HelperFunction.Dateformat(DateTime.Now).ToString();
            //=========detail
            // txtProductName.Text = "";
            ddlProductName.SelectedIndex = 0;
            txtSKUCode.Text = "";
            txtDiscount_2.Value = "0";
            txtMinQtyCases_2.Value = "0";
            txtMaxQtyCases_2.Value = "0";
            ViewState["RequisitionDetail"] = null;
            FillgvProductDetail();
            btnSubmit.Visible = false;
            btnUpdate.Visible = false;

            btnAddNewRequest.Visible = false;
            lblRequisitionSTatus.Text = " (New)";
            //  btnAdd_Detail.Visible = true;
            div_status.Visible = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            if (new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(MisOp.AccountTypes.AM) ||
                new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(MisOp.AccountTypes.TM))
            {
                btnAdd_Detail.Visible = true;
                btnAdd.Visible = true; btnCancel.Visible = true; ;

            }
            else
            {
                btnAdd_Detail.Visible = false;
                btnAdd.Visible = false; btnCancel.Visible = false;
            }
            btnTerminate.Visible = false;
            btnUpdatePopCode.Visible = false;
            btnTerminateApprove.Visible = false;
            btnTerminateReject.Visible = false;
            //lvSkuDetail.ClearSelection();
            lvPopCode.ClearSelection();

            RpAttachment.DataSource = null;
            RpAttachment.DataBind();
            rblCustomer.SelectedIndex = 0;
            txtExistingGM.Text = "";
            txtApprovalRejectionTerminationComments.Text = "";
            //if (new SessionHelper().getUserSession().AccountTyeId >= 5)
            //{
            //    btnBulkApproved.Visible = true;
            //    btnBulkDecline.Visible = true;
            //}
            //else
            //{
            //    btnBulkApproved.Visible = false;
            //    btnBulkDecline.Visible = false;
            //}
        }

        protected void gvProductDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDDELETE.ToString())
            {
                if (ViewState["RequisitionDetail"] != null)
                {
                    int requisitionId = Convert.ToInt32(e.CommandArgument.ToString());
                    requisitionClsList = (List<RequisitionCls>)ViewState["RequisitionDetail"];
                    requisitionClsList = requisitionClsList.Where(a => a.RequisitionDetailId != requisitionId).ToList();
                    ViewState["RequisitionDetail"] = requisitionClsList;
                    FillgvProductDetail();

                }
                else
                {

                }

            }

        }

        protected void btnAdd_Detail_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtMinQtyCases_2.Value) > Convert.ToInt32(txtMaxQtyCases_2.Value))
            {

                heading = "Add Requisition Detail "; type = "error";
                message = "The min quantity can not be greater than max quantity";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }

            ViewState["IsRequisitionDetailModified"] = true;
            //=========add detail
            if (ViewState["RequisitionDetail"] != null)
            {

                requisitionClsList = (List<RequisitionCls>)ViewState["RequisitionDetail"];
                int maxreqDetailId = requisitionClsList.Count > 0 ? requisitionClsList.Max(a => a.RequisitionDetailId) : 0;
                requisitionClsList.Add(new RequisitionCls()
                {
                    RequisitionDetailId = maxreqDetailId + 1,
                    //ProductName = txtProductName.Text,
                    ProductName = ddlProductName.SelectedItem.Text,
                    SKUCode = txtSKUCode.Text,
                    MinQtyMonthCases = Convert.ToInt32(txtMinQtyCases_2.Value),
                    MaxQtyMonthCases = Convert.ToInt32(txtMaxQtyCases_2.Value),
                    Discount = Convert.ToDecimal(txtDiscount_2.Value)
                });
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
                gvProductDetail.Columns[6].Visible = true;
            }
            else
            {
                requisitionClsList = new List<RequisitionCls>();
                requisitionClsList.Add(new RequisitionCls()
                {
                    RequisitionDetailId = 1,
                    // ProductName = txtProductName.Text,
                    ProductName = ddlProductName.SelectedItem.Text,
                    SKUCode = txtSKUCode.Text,
                    MinQtyMonthCases = Convert.ToInt32(txtMinQtyCases_2.Value),
                    MaxQtyMonthCases = Convert.ToInt32(txtMaxQtyCases_2.Value),
                    Discount = Convert.ToDecimal(txtDiscount_2.Value)
                });
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
                gvProductDetail.Columns[6].Visible = true;
            }



            //txtProductName.Text = "";
            ddlProductName.SelectedIndex = 0;
            txtSKUCode.Text = "";
            txtDiscount_2.Value = "0";
            txtMinQtyCases_2.Value = "0";
            txtMaxQtyCases_2.Value = "0";
        }
        public void FillgvProductDetail()
        {
            gvProductDetail.DataSource = (List<RequisitionCls>)ViewState["RequisitionDetail"];
            gvProductDetail.DataBind();

            if (gvProductDetail.Rows.Count > 0)
            {
                gvProductDetail.Columns[6].Visible = false;
                div_total.Visible = true;
                lblMinQtyMonthCases.Text = ((List<RequisitionCls>)ViewState["RequisitionDetail"]).Sum(a => a.MinQtyMonthCases).ToString();
                lblMaxQtyMonthCases.Text = ((List<RequisitionCls>)ViewState["RequisitionDetail"]).Sum(a => a.MaxQtyMonthCases).ToString();
            }
            else
            {
                div_total.Visible = false;
                lblMinQtyMonthCases.Text = "";
                lblMaxQtyMonthCases.Text = "";

            }

        }

        protected void gvRequisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequisition.PageIndex = e.NewPageIndex;
            GetAllRequisition(new SessionHelper().getUserSession().userid);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (lblRequisitionId.Text == "")
            {
                heading = "Requisition Submit";
                message = "Please select requisition from grid";
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }
            else
            {
                bool result = new RequisitionRepository().SubmitRequisition(Convert.ToInt32(lblRequisitionId.Text), new SessionHelper().getUserSession(), ref returnMessage);
                if (result)
                {
                    GetAllRequisition(new SessionHelper().getUserSession().userid);
                    FormReset();
                    heading = "Requisition Submitted";
                    message = "The requisition has been submitted and forwarded to your manager";
                    type = "success";
                    FormStatus(MisOp.FormStatus.ADD);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                    return;

                }
                else
                {
                    heading = "Requisition Submit";
                    message = returnMessage;
                    type = "error";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                    return;
                }
            }



        }

        protected void btnAddNewRequest_Click(object sender, EventArgs e)
        {
            DateTime fromVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime toVal = DateTime.ParseExact(txtTimePeriodFrom.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (fromVal > toVal)
            {
                heading = "Add Requisition "; type = "error";
                message = "The from date can not be greater than to date";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }
            if (gvProductDetail.Rows.Count == 0)
            {
                heading = "Add Requisition "; type = "error";
                message = "Atleast one detail record is required.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;

            }

            requisition = new Requisition();
            requisition = FormToObjectRequisition();
            requisition.RequisitionId = 0;
            requisition.LastModifiedBy = null;
            requisition.LastModifiedDate = null;
            requisition.CreatedBy = new SessionHelper().getUserSession().userid;
            requisition.CreatedDate = DateTime.Now;
            bool result = new RequisitionRepository().SaveRequisition(requisition, ref returnMessage);
            if (result)
            {
                GetAllRequisition(new SessionHelper().getUserSession().userid);
                heading = "Existing Requisition Added";
                message = "The existing requisition has been added as a new requisition.";
                type = "success";
                FormReset();
                requisitionClsList = new List<RequisitionCls>();
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
                FormStatus(MisOp.FormStatus.ADD);
            }
            else
            {
                heading = "Existing Requisition Add";
                message = returnMessage;
                type = "error";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            //=========Reject By the users
            int requisitionId = Convert.ToInt32(lblRequisitionId.Text);
            bool result = new RequisitionRepository().ApproveRejectRequistion(requisitionId,
                new SessionHelper().getUserSession().userid, new SessionHelper().getUserSession().AccountLevel, txtApprovalRejectionTerminationComments.Text,
                MisOp.ApprovalStatus.Approved, ref returnMessage);
            if (result)
            {
                heading = "Requisition Approved";
                message = "The requisition has been approved";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                FormStatus(MisOp.FormStatus.ADD);
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition Approve";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            //=========Reject By the users
            int requisitionId = Convert.ToInt32(lblRequisitionId.Text);
            bool result = new RequisitionRepository().ApproveRejectRequistion(requisitionId,
                new SessionHelper().getUserSession().userid, new SessionHelper().getUserSession().AccountLevel, txtApprovalRejectionTerminationComments.Text,
                MisOp.ApprovalStatus.Reject, ref returnMessage);
            if (result)
            {
                heading = "Requisition rejection";
                message = "The requisition has been rejected";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition rejection";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }

        }

        protected void btnTerminate_Click(object sender, EventArgs e)
        {
            //=========Terminate the Requisition
            int requisitionId = Convert.ToInt32(lblRequisitionId.Text);
            bool result = new RequisitionRepository().RequisitionTerminateRequest(requisitionId, new SessionHelper().getUserSession().userid, ref returnMessage);
            if (result)
            {
                heading = "Requisition termination";
                message = "The requisition has been sent for termination.";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition rejection";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }


        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllRequisition(new SessionHelper().getUserSession().userid);
            FormReset();
        }
        public void FormStatus(MisOp.FormStatus status)
        {
            if (status == MisOp.FormStatus.ADD)
            {
                ddlCompanyCode.Enabled = true;
                txtCustomerName.Enabled = true;
                ddlFunction.Enabled = true;
                lvPopCode.Enabled = true;
                ddlGeography.Enabled = true;
                txtTimePeriodFrom.Enabled = true;
                txtTimePeriodTo.Enabled = true;
                txtPromotionDescriptionandObjective.Enabled = true;
                txtBrandUsedCustomer.Enabled = true;
                txtCustomerBackground.Enabled = true;
                //lvSkuDetail.Enabled = true;
                txtGM.Enabled = true;
                txtMinGSV.Enabled = true;
                txtMaxGSV.Enabled = true;
                txtMinTTS.Enabled = true;
                txtMaxTTS.Enabled = true;
                txtROI.Enabled = true;
                txtComments.Enabled = true;
                ddlProductName.Enabled = true;
                //txtProductName.Enabled = true;
                txtSKUCode.Enabled = false;
                txtDiscount_2.Disabled = false;
                txtMinQtyCases_2.Disabled = false;
                txtMaxQtyCases_2.Disabled = false;
                d_FileUpload.Visible = false;
                rblCustomer.Enabled = true;
                txtExistingGM.Enabled = true;

            }
            else if (status == MisOp.FormStatus.EDIT)
            {
                ddlCompanyCode.Enabled = true;
                txtCustomerName.Enabled = true;
                ddlFunction.Enabled = true;
                lvPopCode.Enabled = true;
                ddlGeography.Enabled = true;
                txtTimePeriodFrom.Enabled = true;
                txtTimePeriodTo.Enabled = true;
                txtPromotionDescriptionandObjective.Enabled = true;
                txtBrandUsedCustomer.Enabled = true;
                txtCustomerBackground.Enabled = true;
                //lvSkuDetail.Enabled = true;
                txtGM.Enabled = true;
                txtMinGSV.Enabled = true;
                txtMaxGSV.Enabled = true;
                txtMinTTS.Enabled = true;
                txtMaxTTS.Enabled = true;
                txtROI.Enabled = true;
                txtComments.Enabled = true;

                ddlProductName.Enabled = true;
                // txtProductName.Enabled = true;
                txtSKUCode.Enabled = false;
                txtDiscount_2.Disabled = false;
                txtMinQtyCases_2.Disabled = false;
                txtMaxQtyCases_2.Disabled = false;
                d_FileUpload.Visible = true;
                fupRequisition.Visible = true;
                lblFileUpload.Visible = true;
                btnUpload.Visible = true;
                rblCustomer.Enabled = true;
                txtExistingGM.Enabled = true;
            }
            else if (status == MisOp.FormStatus.VIEW)
            {
                ddlCompanyCode.Enabled = false;
                txtCustomerName.Enabled = false;
                ddlFunction.Enabled = false;
                lvPopCode.Enabled = true;
                //lvPopCode.Attributes.Add("shouldEnable", "false");
                //lvPopCode.Style["chosen"] = "updated";
                ddlGeography.Enabled = false;
                txtTimePeriodFrom.Enabled = false;
                txtTimePeriodTo.Enabled = false;
                txtPromotionDescriptionandObjective.Enabled = false;
                txtBrandUsedCustomer.Enabled = false;
                txtCustomerBackground.Enabled = false;
                //lvSkuDetail.Enabled = false;
                txtGM.Enabled = false;
                txtMinGSV.Enabled = false;
                txtMaxGSV.Enabled = false;
                txtMinTTS.Enabled = false;
                txtMaxTTS.Enabled = false;
                txtROI.Enabled = false;
                txtComments.Enabled = false;
                ddlProductName.Enabled = false;
                // txtProductName.Enabled = false;
                txtSKUCode.Enabled = false;
                txtDiscount_2.Disabled = true;
                txtMinQtyCases_2.Disabled = true;
                txtMaxQtyCases_2.Disabled = true;
                txtApprovalRejectionTerminationComments.Enabled = false;
                d_FileUpload.Visible = true;
                fupRequisition.Visible = false;
                lblFileUpload.Visible = false;
                btnUpload.Visible = false;
                rblCustomer.Enabled = false;
                txtExistingGM.Enabled = false;
            }

            else if (status == MisOp.FormStatus.ACTION)
            {
                ddlCompanyCode.Enabled = false;
                txtCustomerName.Enabled = false;
                ddlFunction.Enabled = false;
                lvPopCode.Enabled = false;
                ddlGeography.Enabled = false;
                txtTimePeriodFrom.Enabled = false;
                txtTimePeriodTo.Enabled = false;
                txtPromotionDescriptionandObjective.Enabled = false;
                txtBrandUsedCustomer.Enabled = false;
                txtCustomerBackground.Enabled = false;
                //lvSkuDetail.Enabled = false;
                txtGM.Enabled = false;
                txtMinGSV.Enabled = false;
                txtMaxGSV.Enabled = false;
                txtMinTTS.Enabled = false;
                txtMaxTTS.Enabled = false;
                txtROI.Enabled = false;
                txtComments.Enabled = false;
                ddlProductName.Enabled = false;
                //txtProductName.Enabled = false;
                txtSKUCode.Enabled = false;
                txtDiscount_2.Disabled = true;
                txtMinQtyCases_2.Disabled = true;
                txtMaxQtyCases_2.Disabled = true;
                txtApprovalRejectionTerminationComments.Enabled = true;
                d_FileUpload.Visible = true;
                fupRequisition.Visible = false;
                lblFileUpload.Visible = false;
                btnUpload.Visible = false;
                rblCustomer.Enabled = false;
                txtExistingGM.Enabled = false;
            }


        }

        protected void btnUpdatePopCode_Click(object sender, EventArgs e)
        {
            requisition = new Requisition();
            requisition = FormToObjectRequisition();
            bool result = new RequisitionRepository().UpdateRequisitionPopCode(requisition, ref returnMessage);
            if (result)
            {
                GetAllRequisition(new SessionHelper().getUserSession().userid);
                heading = "Requisition Updated";
                message = "The Requisition pop code has been updated.";
                type = "success";
                FormReset();
                requisitionClsList = new List<RequisitionCls>();
                ViewState["RequisitionDetail"] = requisitionClsList;
                FillgvProductDetail();
            }
            else
            {
                heading = "Requisition Updated";
                message = returnMessage;
                type = "error";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


        }

        protected void btnTerminateApprove_Click(object sender, EventArgs e)
        {
            //=========Reject By the users
            int requisitionId = Convert.ToInt32(lblRequisitionId.Text);
            bool result = new RequisitionRepository().RequisitionTerminateDecision(requisitionId, true, ref returnMessage);
            if (result)
            {
                heading = "Requisition Termination";
                message = "The requisition has been terminated";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset(); FormStatus(MisOp.FormStatus.ADD);
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition Termination";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }

        }

        protected void btnTerminateReject_Click(object sender, EventArgs e)
        {
            //=========Reject By the users
            int requisitionId = Convert.ToInt32(lblRequisitionId.Text);
            bool result = new RequisitionRepository().RequisitionTerminateDecision(requisitionId, false, ref returnMessage);
            if (result)
            {
                heading = "Requisition Termination";
                message = "The requisition has been rejected for termination";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition Termination";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductName.SelectedIndex > 0)
            {
                txtSKUCode.Text = new ProductRepository().GetProductByProductId(Convert.ToInt32(ddlProductName.SelectedValue)).ProductCode;

            }
            else
            {
                txtSKUCode.Text = "";
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            heading = "Requisition Attachment";
            type = "error";
            message = "Please select file";
            if (!fupRequisition.HasFile)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }
            //get File size in MB
            double fileSize = (fupRequisition.PostedFile.ContentLength / 1024) / 1024.0;
            if (fileSize > 4.0)
            {
                message = "Maxmimun 4MB file size is allowed";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }


            string filePath = fupRequisition.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string extension = Path.GetExtension(filename);
            //if (extension.ToUpper() != ".PDF" && extension.ToUpper() != ".DOC" && extension.ToUpper() != ".DOCX")
            //{
            //    returnMessage = "Incorrect format. Please upload a PDF or Word document";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + returnMessage + "','" + type + "')", true);
            //    return;
            //}
            string contentType = getContentType(extension);
            Stream fs = fupRequisition.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] contentdata = br.ReadBytes((Int32)fs.Length);
            RequisitionAttachement ra = new RequisitionAttachement();
            ra.RequisitionId = Convert.ToInt32(lblRequisitionId.Text);
            ra.ContentData = contentdata;
            ra.ContentType = contentType;
            ra.format = extension;
            ra.IsActive = true;
            ra.fileName = filename;
            ra.CreatedBy = new SessionHelper().getUserSession().userid;
            ra.CreatedDate = DateTime.Now;
            if (new RequisitionAttachmentRepository().SaveRequisitionAttachment(ra, ref returnMessage))
            {
                type = "success";
            }
            getAttachmentByRequisitionId(Convert.ToInt32(lblRequisitionId.Text));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + returnMessage + "','" + type + "')", true);
            return;
        }
        public static string getContentType(string extension)
        {
            string contenttype = "";
            switch (extension)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            return contenttype;

        }

        public void RequisitionAttachment(List<RequisitionAttachement> lstRA)
        {
            RpAttachment.DataSource = lstRA;
            RpAttachment.DataBind();
        }
        public void getAttachmentByRequisitionId(int requisitionId)
        {
            var result = new RequisitionAttachmentRepository().GetAllRequisitionAttachmentByRequisitionId(requisitionId);
            RequisitionAttachment(result);
        }

        protected void RpAttachment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            heading = "Requisition attachment deletion";
            type = "error";
            if (e.CommandName.ToUpper() == "DOWNLOAD")
            {
                requisitionAttachmentRepository = new RequisitionAttachmentRepository();
                try
                {
                    var obj_file = requisitionAttachmentRepository.GetRequisitionAttachmentById(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (obj_file != null)
                    {
                        DownloadFile(obj_file.ContentType, String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now) + obj_file.fileName, obj_file.ContentData);
                    }
                }
                catch (Exception)
                {
                }

            }
            else if (e.CommandName.ToUpper() == "GRIDDELETE")
            {
                if (new RequisitionAttachmentRepository().DeleteRequisitionAttachment(Convert.ToInt32(e.CommandArgument.ToString()), ref returnMessage))
                {
                    type = "success";
                }
                getAttachmentByRequisitionId(Convert.ToInt32(lblRequisitionId.Text));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + returnMessage + "','" + type + "')", true);
                return;

            }

        }
        public static void DownloadFile(string contentType, string fileName, byte[] bytes)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = contentType;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        protected void ddlCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["RequisitionDetail"] = null;
            FillgvProductDetail();

            if (ddlCompanyCode.SelectedIndex == 0)
            {
                GetAllProductName();
                txtSKUCode.Text = "";
            }
            else
            {
                fillproductbycompanyid();
            }

        }
        public void fillproductbycompanyid()
        {
            new MiscellaneousOperation().GetAllProductByCompanyId(ref ddlProductName, Convert.ToInt32(ddlCompanyCode.SelectedValue));
        }

        protected void btnBulkApproved_Click(object sender, EventArgs e)
        {
            //=========Approved By the users
            List<int> allCheckIds = GetAllCheckedRecord();
            if (allCheckIds.Count == 0)
            {
                heading = "Requisition Approve";
                message = "Select atleast 1 requistion";
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }

            bool result = new RequisitionRepository().ApproveRejectRequistion_Bulk(
                new SessionHelper().getUserSession().userid,
                new SessionHelper().getUserSession().AccountLevel,
                txtApprovalRejectionTerminationComments.Text, MisOp.ApprovalStatus.Approved, allCheckIds, ref returnMessage);
            if (result)
            {
                heading = "Requisition Approved";
                message = "All selected requisitions have been approved";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                FormStatus(MisOp.FormStatus.ADD);
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition Approve";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            }
        }

        protected void btnBulkDecline_Click(object sender, EventArgs e)
        {
            List<int> allCheckIds = GetAllCheckedRecord();
            if (allCheckIds.Count == 0)
            {
                heading = "Requisition Decline";
                message = "Select atleast 1 requistion";
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                return;
            }

            //=========Approved By the users
            bool result = new RequisitionRepository().ApproveRejectRequistion_Bulk(
                new SessionHelper().getUserSession().userid,
                new SessionHelper().getUserSession().AccountLevel,
                txtApprovalRejectionTerminationComments.Text,
                MisOp.ApprovalStatus.Reject, allCheckIds, ref returnMessage);
            if (result)
            {
                heading = "Requisition Rejected";
                message = "All selected requisitions have been rejected";
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                FormReset();
                FormStatus(MisOp.FormStatus.ADD);
                GetAllRequisition(new SessionHelper().getUserSession().userid);
            }
            else
            {
                heading = "Requisition Reject";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            }
        }


        protected void chboxSelectHead_CheckedChanged(object sender, EventArgs e)
        {
            bool chbHead = ((CheckBox)sender).Checked;

            for (int i = 0; i < gvRequisition.Rows.Count; i++)
            {
                var chk = (CheckBox)(gvRequisition.Rows[i].Cells[0].FindControl("chboxSelectItem"));
                if (chk != null)
                {
                    chk.Checked = chbHead;
                }
            }
        }
        public List<int> GetAllCheckedRecord()
        {
            List<int> CheckedIds = new List<int>();
            for (int i = 0; i < gvRequisition.Rows.Count; i++)
            {
                var chk = (CheckBox)(gvRequisition.Rows[i].Cells[0].FindControl("chboxSelectItem"));
                if (chk != null && chk.Checked)
                {
                    CheckedIds.Add(Convert.ToInt32(chk.ToolTip));
                }
            }
            return CheckedIds;
        }
    }
}