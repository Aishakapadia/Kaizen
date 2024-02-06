using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class RequisitionAttachmentRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public RequisitionAttachmentRepository()
        {
            context = new UFSEntitiess();
        }
        public bool SaveRequisitionAttachment(RequisitionAttachement ra, ref string returnMessage)
        {
            try
            {
                result = false;
                using (context)
                {

                    context.RequisitionAttachements.Add(ra);
                    returnMessage = "Requisition document has been saved successfully.";

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message;
                return false;
            }
        }
        public bool DeleteRequisitionAttachment(int requisitionAttachmentId, ref string returnMessage)
        {
            result = false;
            using (context)
            {


                var requisitionAttachmentObj = context.RequisitionAttachements.Where(a => a.RequisitionAttachementId == requisitionAttachmentId).FirstOrDefault();
                if (requisitionAttachmentObj != null && requisitionAttachmentObj.RequisitionAttachementId > 0)
                {
                    requisitionAttachmentObj.IsActive = false;
                    context.SaveChanges();
                    returnMessage = "Requisition attachment has been deleted successfully.";
                    return true;
                }
                else
                {
                    returnMessage = "No attachment found.";
                }
                return false;
            }
        }
        public List<RequisitionAttachement> GetAllRequisitionAttachmentByRequisitionId(int requisitionId)
        {
            return context.RequisitionAttachements.Include("User").Where(a => a.RequisitionId == requisitionId && a.IsActive == true).ToList();
        }
        public RequisitionAttachement GetRequisitionAttachmentById(int requisitionAttachmentId)
        {
            return context.RequisitionAttachements.Where(a => a.RequisitionAttachementId == requisitionAttachmentId).FirstOrDefault();
        }
    }
}