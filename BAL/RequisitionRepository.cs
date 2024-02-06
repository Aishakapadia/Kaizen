using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.App_class;
using UFS_Application.DAL;
using static UFS_Application.App_class.MisOp;

namespace UFS_Application.BAL
{
    public class RequisitionRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public RequisitionRepository()
        {
            context = new UFSEntitiess();

        }
        public List<Requisition> GetAllRequisition(int userid, int currentfiltervalue)
        {
            var userObj = new UserRepository().GetUserByUserId(userid);

            int pendingStatus = Convert.ToInt32(ApprovalStatus.Pending);

            return context.Requisitions.Include("User").Include("Company").Include("Function").
                Where(a => a.IsActive == true
                && (currentfiltervalue == -1 || a.RequisitionStatus == currentfiltervalue)
                 &&
                 ((a.RequisitionApprovalStatusDetails.Any(b => b.UserId == userid && b.ApprovalStatus == pendingStatus && b.IsActive == true))
                 ||
                 (a.CreatedBy == userid)
                 ||
                 (userObj.AccountTypeId == 4 && a.RequisitionStatus == 3)
                 ||
                  (userObj.AccountTypeId == 5 && a.RequisitionStatus == 3 && a.IsTerminationRequested == true)
                 )
                 //&& (userObj.AccountTypeId==4
                 ).OrderByDescending(a => a.RequisitionId).ToList();
        }
        public bool DeleteRequisitionByRequisitionId(int RequisitionId)
        {
            result = false;
            using (context)
            {
                Requisition RequisitionObj = context.Requisitions.Where(a => a.RequisitionId == RequisitionId).FirstOrDefault();
                if (RequisitionObj != null && RequisitionObj.RequisitionId > 0)
                {
                    RequisitionObj.IsActive = false;
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public Requisition GetRequisitionByRequisitionId(int Requisition, ref string returnMessage)
        {
            return context.Requisitions.Include("RequisitionApprovalStatusDetails").Include("Requisition_Detail")
                .Include("RequisitionPopCodes")
                .Include("RequisitionSKUDetails")
                          .Where(a => a.RequisitionId == Requisition
                          && a.IsActive == true).FirstOrDefault();
        }
        public bool SaveRequisition(Requisition requisition, ref string returnMessage)
        {

            result = false;
            using (context)
            {
                if (requisition.RequisitionId > 0)
                {
                    var requisitionObj = context.Requisitions.Where(a => a.RequisitionId == requisition.RequisitionId).FirstOrDefault();
                    if (requisitionObj != null && requisitionObj.RequisitionId > 0)
                    {
                        requisitionObj.CompanyId = requisition.CompanyId;
                        requisitionObj.CustomerName = requisition.CustomerName;
                        requisitionObj.FunctionId = requisition.FunctionId;
                        requisitionObj.Geography = requisition.Geography;
                        requisitionObj.FromTime = requisition.FromTime;
                        requisitionObj.ToTime = requisition.ToTime;
                        requisitionObj.CustomerBackground = requisition.CustomerBackground;
                        requisitionObj.BrandUserCustomer = requisition.BrandUserCustomer;
                        requisitionObj.PromotionDesc = requisition.PromotionDesc;
                        requisitionObj.Total = requisition.Total;
                        requisitionObj.ROI = requisition.ROI;
                        requisitionObj.GM = requisition.GM;
                        requisitionObj.MinGSV = requisition.MinGSV;
                        requisitionObj.MaxGSV = requisition.MaxGSV;
                        requisitionObj.MinTTS = requisition.MinTTS;
                        requisitionObj.MaxTTS = requisition.MaxTTS;
                        requisitionObj.LastModifiedBy = requisition.LastModifiedBy;
                        requisitionObj.LastModifiedDate = DateTime.Now;
                        requisitionObj.IsActive = requisition.IsActive;
                        requisitionObj.TotalMinQtyMonthCases = requisition.TotalMinQtyMonthCases;
                        requisitionObj.TotalMaxQtyMonthCases = requisition.TotalMaxQtyMonthCases;
                        requisitionObj.RequisitionStatus = requisition.RequisitionStatus;
                        requisitionObj.Comments = requisition.Comments;
                        requisitionObj.IsNewUser = requisition.IsNewUser;
                        requisitionObj.ExistingGM = requisition.ExistingGM;
                        //requisition.IsTerminationRequested = false;
                        //===============Requisition Detail(Remove existing)
                        int noOfRowDeleted = context.Database.ExecuteSqlCommand("delete from Requisition_Detail where RequisitionId = " + requisition.RequisitionId);
                        requisitionObj.Requisition_Detail = requisition.Requisition_Detail;

                        //===============Requisition Detail(Remove existing)
                        int noOfRowDeletedRequisitionPopCode = context.Database.ExecuteSqlCommand("delete from RequisitionPopCode where RequisitionId = " + requisition.RequisitionId);
                        requisitionObj.RequisitionPopCodes = requisition.RequisitionPopCodes;

                        ////===============Requisition Detail(Remove existing)
                        //int noOfRowDeletedRequisitionSKUDetail = context.Database.ExecuteSqlCommand("delete from RequisitionSKUDetail where RequisitionId = " + requisition.RequisitionId);
                        //requisitionObj.RequisitionSKUDetails = requisition.RequisitionSKUDetails;

                    }
                }
                else
                {
                    // requisition.CreatedBy = requisition.Comments;
                    requisition.CreatedDate = DateTime.Now;
                    // Requisition.LineManagerId = linemanagerId;
                    context.Requisitions.Add(requisition);
                }
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool SubmitRequisition(int requisitionId, UserSession user, ref string ErrorMessage)
        {
            result = false;
            var requisitionObj = context.Requisitions.Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
            if (requisitionObj != null && requisitionObj.RequisitionId > 0)
            {
                if (requisitionObj.RequisitionStatus > 0)
                {
                    ErrorMessage = "The requisition has already been submitted.";
                    return result;
                }
                requisitionObj.RequisitionStatus = 1;

                //=================Get AccountType
                int accountTypeId = user.AccountTyeId;
                var accountTypeObj = context.AccountTypes.Where(a => a.AccountTypeId == accountTypeId).FirstOrDefault();//=========get current user a/c type
                var accountType_Next_AccountTypeId = context.AccountTypes.Where(a => a.AccountLevel > accountTypeObj.AccountLevel).FirstOrDefault().AccountTypeId;//=========get Next user a/c type
                //=============Get User Head
                int regionId = user.RegionId;
                var user_NextObj = context.Users.Where(a => a.AccountTypeId == accountType_Next_AccountTypeId && a.RegionId == regionId).FirstOrDefault();
                if (user_NextObj == null)
                {
                    ErrorMessage = "The supervisor does not exists.";
                    return result;
                }

                //=============End Get User Head
                //==========Add RequisitionApprovalStatus
                RequisitionApprovalStatusDetail requisitionApprovalStatu = new DAL.RequisitionApprovalStatusDetail();
                requisitionApprovalStatu.RequisitionId = requisitionId;
                requisitionApprovalStatu.UserId = user_NextObj.UserId;
                requisitionApprovalStatu.ApprovalStatus = 1;
                requisitionApprovalStatu.CreatedBy = requisitionObj.CreatedBy;
                requisitionApprovalStatu.CreatedDate = DateTime.Now;
                requisitionApprovalStatu.IsActive = true;
                context.RequisitionApprovalStatusDetails.Add(requisitionApprovalStatu);
                //===========End



                context.SaveChanges();
                result = true;
            }
            ErrorMessage = "No record found";
            return result;
        }


        public bool ApproveRejectRequistion(int requisitionId, int userid, int accountTypelevel, string comments, ApprovalStatus status, ref string ErrorMessage)
        {
            var requisitionObj = context.Requisitions.Include("RequisitionApprovalStatusDetails").Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
            if (requisitionObj != null)
            {
                var requisitionDetailObj = requisitionObj.RequisitionApprovalStatusDetails.Where(a => a.UserId == userid && a.IsActive == true).FirstOrDefault();

                if (requisitionDetailObj == null)
                {
                    ErrorMessage = "No record found";
                    return false;
                }
                if (requisitionDetailObj.ApprovalStatus > Convert.ToInt32(ApprovalStatus.Pending))
                {
                    ErrorMessage = "The decision has already been taken agaisnt the requisition.";
                    return false;
                }
                if (status == ApprovalStatus.Reject)
                {
                    requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Reject);
                    requisitionObj.RequisitionStatus = Convert.ToInt32(ApprovalStatus.Reject);
                    requisitionDetailObj.LastModifiedBy = userid;
                    requisitionDetailObj.LastModifiedDate = DateTime.Now;
                    requisitionDetailObj.Comments = comments;
                }
                else if (status == ApprovalStatus.Approved)
                {
                    requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Approved);
                    if (accountTypelevel == Convert.ToInt32(AccountTypes.CH))
                    {
                        requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Approved);
                        requisitionObj.RequisitionStatus = Convert.ToInt32(ApprovalStatus.Approved);
                        requisitionDetailObj.LastModifiedBy = userid;
                        requisitionDetailObj.LastModifiedDate = DateTime.Now;
                        requisitionDetailObj.Comments = comments;
                    }
                    else
                    {
                        //===========Get above accountTypelevel
                        requisitionDetailObj.LastModifiedBy = userid;
                        requisitionDetailObj.LastModifiedDate = DateTime.Now;
                        requisitionDetailObj.Comments = comments;
                        var accountTypeId = context.AccountTypes.Where(a => a.AccountLevel > accountTypelevel)
                            .OrderBy(a => a.AccountLevel).FirstOrDefault().AccountTypeId;
                        var NextuserObj = context.Users.Where(a => a.AccountTypeId == accountTypeId).FirstOrDefault();
                        if (NextuserObj != null)
                        {
                            RequisitionApprovalStatusDetail requisitionApprovalStatusDetail = new DAL.RequisitionApprovalStatusDetail();
                            requisitionApprovalStatusDetail.RequisitionId = requisitionId;
                            requisitionApprovalStatusDetail.UserId = NextuserObj.UserId;
                            requisitionApprovalStatusDetail.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Pending);

                            requisitionApprovalStatusDetail.CreatedBy = userid;
                            requisitionApprovalStatusDetail.CreatedDate = DateTime.Now;
                            requisitionApprovalStatusDetail.IsActive = true;
                            context.RequisitionApprovalStatusDetails.Add(requisitionApprovalStatusDetail);
                        }
                        else
                        {
                            ErrorMessage = "The supervisor is not exists. Please complate hierarchy.";
                            return false;
                        }

                    }


                }
                context.SaveChanges();
                return true;
            }
            else
            {
                ErrorMessage = "No record found";
                return false;
            }
            return false;
        }


        public bool UpdateRequisitionPopCode(Requisition requisition, ref string returnMessage)
        {
            //==================update pop code
            result = false;
            using (context)
            {
                if (requisition.RequisitionId > 0)
                {
                    var requisitionObj = context.Requisitions.Where(a => a.RequisitionId == requisition.RequisitionId).FirstOrDefault();
                    if (requisitionObj != null && requisitionObj.RequisitionId > 0)
                    {
                        //==================update pop code
                        int noOfRowDeletedRequisitionPopCode = context.Database.ExecuteSqlCommand("delete from RequisitionPopCode where RequisitionId = " + requisition.RequisitionId);
                        requisitionObj.RequisitionPopCodes = requisition.RequisitionPopCodes;
                    }
                }
                context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool RequisitionTerminateRequest(int requisitionId, int userid, ref string returnMessage)
        {
            //==================update pop code
            result = false;
            using (context)
            {
                var requisitionObj = context.Requisitions.Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
                if (requisitionObj != null && requisitionObj.RequisitionId > 0)
                {
                    if (requisitionObj.IsTerminationRequested)
                    {
                        returnMessage = "The requisition has already been sent to terminate.";
                        result = false; return result;
                    }
                    //==================update pop code
                    requisitionObj.IsTerminationRequested = true;
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool RequisitionTerminateDecision(int requisitionId, bool status, ref string returnMessage)
        {
            //==================update pop code
            result = false;
            using (context)
            {
                var requisitionObj = context.Requisitions.Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
                if (requisitionObj != null && requisitionObj.RequisitionId > 0)
                {
                    if (!requisitionObj.IsTerminationRequested)
                    {
                        returnMessage = "There is no requisition to terminate the request";
                        result = false; return result;
                    }
                    //==================update pop code
                    requisitionObj.IsTerminationRequested = false;
                    requisitionObj.RequisitionStatus = status ? 4 : 3;
                    requisitionObj.LastModifiedBy = requisitionObj.CreatedBy;
                    requisitionObj.LastModifiedDate = DateTime.Now;
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public List<GetRequisitionAuditById_Result> GetRequisitionAuditById(int requisitionId)
        {

            using (context)
            {
                return context.GetRequisitionAuditById(requisitionId).ToList();
            }

        }

        public bool ApproveRejectRequistion_Bulk(int userid, int accountTypelevel, string comments, ApprovalStatus status, List<int> RequistionList, ref string ErrorMessage)
        {
            //List<int> RequisitionIdsForBulkOperation = new List<int>();
            //var requistionList = context.RequisitionApprovalStatusDetails.Where(a => a.UserId == userid &&
            //a.ApprovalStatus == 1 && a.IsActive == true).ToList();
            //foreach (var item in requistionList)
            //{
            //    RequisitionIdsForBulkOperation.Add(item.RequisitionId.Value);
            //}
            //if (RequisitionIdsForBulkOperation.Count == 0)
            //{
            //    ErrorMessage = "No pending requistion exists.";
            //    return false;
            //}
            if (RequistionList.Count == 0)
            {
                ErrorMessage = "No pending requistion exists.";
                return false;
            }


            //foreach (var requisitionId in RequisitionIdsForBulkOperation)
            foreach (var requisitionId in RequistionList)
            {

                var requisitionObj = context.Requisitions.Include("RequisitionApprovalStatusDetails")
                    .Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
                if (requisitionObj != null)
                {
                    var requisitionDetailObj = requisitionObj.RequisitionApprovalStatusDetails.Where(a => a.UserId == userid && a.IsActive == true).FirstOrDefault();

                    //if (requisitionDetailObj == null)
                    //{
                    //    ErrorMessage = "No record found fro";
                    //    return false;
                    //}
                    if (requisitionDetailObj.ApprovalStatus > Convert.ToInt32(ApprovalStatus.Pending))
                    {
                        ErrorMessage = "The decision has already been taken agaisnt the requisition ID."+ requisitionDetailObj.RequisitionId;
                        return false;
                    }
                    if (status == ApprovalStatus.Reject)
                    {
                        requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Reject);
                        requisitionObj.RequisitionStatus = Convert.ToInt32(ApprovalStatus.Reject);
                        requisitionDetailObj.LastModifiedBy = userid;
                        requisitionDetailObj.LastModifiedDate = DateTime.Now;
                        requisitionDetailObj.Comments = comments;
                    }
                    else if (status == ApprovalStatus.Approved)
                    {
                        requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Approved);
                        if (accountTypelevel == Convert.ToInt32(AccountTypes.CH))
                        {
                            requisitionDetailObj.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Approved);
                            requisitionObj.RequisitionStatus = Convert.ToInt32(ApprovalStatus.Approved);
                            requisitionDetailObj.LastModifiedBy = userid;
                            requisitionDetailObj.LastModifiedDate = DateTime.Now;
                            requisitionDetailObj.Comments = comments;
                        }
                        else
                        {
                            //===========Get above accountTypelevel
                            requisitionDetailObj.LastModifiedBy = userid;
                            requisitionDetailObj.LastModifiedDate = DateTime.Now;
                            requisitionDetailObj.Comments = comments;
                            var accountTypeId = context.AccountTypes.Where(a => a.AccountLevel > accountTypelevel)
                                .OrderBy(a => a.AccountLevel).FirstOrDefault().AccountTypeId;
                            var NextuserObj = context.Users.Where(a => a.AccountTypeId == accountTypeId).FirstOrDefault();
                            if (NextuserObj != null)
                            {
                                RequisitionApprovalStatusDetail requisitionApprovalStatusDetail = new DAL.RequisitionApprovalStatusDetail();
                                requisitionApprovalStatusDetail.RequisitionId = requisitionId;
                                requisitionApprovalStatusDetail.UserId = NextuserObj.UserId;
                                requisitionApprovalStatusDetail.ApprovalStatus = Convert.ToInt32(ApprovalStatus.Pending);

                                requisitionApprovalStatusDetail.CreatedBy = userid;
                                requisitionApprovalStatusDetail.CreatedDate = DateTime.Now;
                                requisitionApprovalStatusDetail.IsActive = true;
                                context.RequisitionApprovalStatusDetails.Add(requisitionApprovalStatusDetail);
                            }
                            else
                            {
                                ErrorMessage = "The supervisor is not exists. Please complate hierarchy.";
                                return false;
                            }

                        }


                    }
                    context.SaveChanges();
                    // return true;
                }
                else
                {
                    ErrorMessage = "No record found";
                    return false;
                }
            }
            ErrorMessage = "All selected requisitions have been " + (status == ApprovalStatus.Approved ? "approved" : "declined");
            return true;
        }

    }
}