using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Configuration;
using System.Net;
using System.Configuration;
//using DAL.BAL;
//using DAL;
using System.Web.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using UFS_Application.DAL;
using UFS_Application.BAL;

namespace UFS_Application.App_class
{
    public class EmailCreation
    {
        public static readonly string fromEmailAddress = "talent.orgpk@unilever.com";
        public string returnMessage;

        /// <summary>
        /// 1
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_InitiatorSubmit_1(int req_Id, ref string returnMessage)
        {
            //===================
            var requistionObj = GetRequisitionByID(req_Id);
            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                //var pendingRequisitionObj= requistionObj.RequisitionApprovalStatusDetails.Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Pending)).FirstOrDefault();
                //  if(pendingRequisitionObj!=null)
                //  {
                var userObj = new UserRepository().GetUserByUserId(requistionObj.CreatedBy.Value);
                if (userObj != null)
                {
                    toEmail = userObj.EmailAddress.Replace("\r\n", "");
                }
                //  }
            }

            //===================
            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been successfully uploaded. It has been " +
                                "sent to stage 1 for approval." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = "Upload Status - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_ApprovalPending_5(int req_Id, ref string returnMessage)
        {


            //===================
            var requistionObj = GetRequisitionByID(req_Id);
            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                var pendingRequisitionObj = requistionObj.RequisitionApprovalStatusDetails.Where(a => 
                a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Pending)).FirstOrDefault();
                if (pendingRequisitionObj != null)
                {
                    var userObj = new UserRepository().GetUserByUserId(pendingRequisitionObj.UserId.Value);
                    if (userObj != null)
                    {
                        toEmail = userObj.EmailAddress.Replace("\r\n", "");
                    }
                }
            }






            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  approval is pending at your end on Kaizen." +
                                "Kindly approve it." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = "Kaizen Approval Required - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_ApprovalSucess_Initiator_2(int req_Id, ref string returnMessage)
        {
            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Approved";
            string approverName = "";
            string stage = "";
            Email objEmail = new Email();

            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                var lastApprovRequisitionObj = requistionObj.RequisitionApprovalStatusDetails
                    .Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Approved))
                    .OrderByDescending(a => a.RequisitionApprovalStatusId).FirstOrDefault();
                if (lastApprovRequisitionObj != null)
                {
                    var userObj_approver = new UserRepository().GetUserByUserId(lastApprovRequisitionObj.UserId.Value);
                    if (userObj_approver != null)
                    {
                        approverName = userObj_approver.UserName.Replace("\r\n", "");
                        stage = (userObj_approver.AccountType.AccountLevel).ToString();
                    }

                    var userObj_Initiator = new UserRepository().GetUserByUserId(requistionObj.CreatedBy.Value);
                    if (userObj_Initiator != null)
                    {
                        toEmail = userObj_Initiator.EmailAddress.Replace("\r\n", "");
                    }
                }
            }


            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been approved by " + approverName + "." +
                                " It has been sent to Stage <b>" + stage + "</b> for approval." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_ApprovalReject_Initiator_3(int req_Id, ref string returnMessage)
        {

            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Rejected";
            string approverName = "";
            string stage = "";

            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                var lastApprovRequisitionObj = requistionObj.RequisitionApprovalStatusDetails
                    .Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Reject))
                    .OrderByDescending(a => a.RequisitionApprovalStatusId).FirstOrDefault();
                if (lastApprovRequisitionObj != null)
                {
                    var userObj_approver = new UserRepository().GetUserByUserId(lastApprovRequisitionObj.UserId.Value);
                    if (userObj_approver != null)
                    {
                        approverName = userObj_approver.UserName.Replace("\r\n", "");
                        stage = (userObj_approver.AccountType.AccountLevel-1).ToString();
                    }

                    var userObj_Initiator = new UserRepository().GetUserByUserId(requistionObj.CreatedBy.Value);
                    if (userObj_Initiator != null)
                    {
                        toEmail = userObj_Initiator.EmailAddress.Replace("\r\n", "");
                    }
                }
            }



            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been rejected by " + approverName + " on stage  <b>" + stage + "</b>." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_FinalApproval_4(int req_Id, ref string returnMessage)
        {
            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Approved";
            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                //var pendingRequisitionObj= requistionObj.RequisitionApprovalStatusDetails.Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Pending)).FirstOrDefault();
                //  if(pendingRequisitionObj!=null)
                //  {
                var userObj = new UserRepository().GetUserByUserId(requistionObj.CreatedBy.Value);
                if (userObj != null)
                {
                    toEmail = userObj.EmailAddress.Replace("\r\n", "");
                }
                //  }
            }



            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been approved by all approvers. " +
                                "Kindly update MIS Team to activate this contract in this system." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 6
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_ApprovalSucess_SamePerson_6(int req_Id, ref string returnMessage)
        {
            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Approved";
            string approverName = "";
            string stage = "";
            bool isCountryHead = false;
            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                var lastApprovRequisitionObj = requistionObj.RequisitionApprovalStatusDetails
                    .Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Approved))
                    .OrderByDescending(a => a.RequisitionApprovalStatusId).FirstOrDefault();
                if (lastApprovRequisitionObj != null)
                {
                    var userObj_approver = new UserRepository().GetUserByUserId(lastApprovRequisitionObj.UserId.Value);
                    if (userObj_approver != null)
                    {
                        approverName = userObj_approver.UserName.Replace("\r\n", "");
                        stage = (userObj_approver.AccountType.AccountLevel).ToString();
                        toEmail = userObj_approver.EmailAddress.Replace("\r\n", "");
                        isCountryHead = userObj_approver.AccountType.AccountLevel == 5 ? true : false;
                    }


                }
            }







            Email objEmail = new Email();
            string addStage = "It has been sent to Stage <b>" + stage + "</b> for approval.";
            if (isCountryHead)
            {
                addStage = "";
            }
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been approved by you. " +
                                 addStage +
                                "<br><br>" + "Regards,<br>Kaizen</p>");



            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 7
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_ApprovalReject_SamePerson_7(int req_Id, ref string returnMessage)
        {

            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Rejected";
            string approverName = "";
            string stage = "";

            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                var lastApprovRequisitionObj = requistionObj.RequisitionApprovalStatusDetails
                    .Where(a => a.ApprovalStatus == Convert.ToInt32(MisOp.ApprovalStatus.Approved))
                    .OrderByDescending(a => a.RequisitionApprovalStatusId).FirstOrDefault();
                if (lastApprovRequisitionObj != null)
                {
                    var userObj_approver = new UserRepository().GetUserByUserId(lastApprovRequisitionObj.UserId.Value);
                    if (userObj_approver != null)
                    {
                        approverName = userObj_approver.UserName.Replace("\r\n", "");
                        stage = (userObj_approver.AccountType.AccountLevel - 1).ToString();

                        toEmail = userObj_approver.EmailAddress.Replace("\r\n", "");
                    }


                }
            }
            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been rejected by you on stage  <b>" + stage + "</b>. It has been sent back for Re-Evaluation." +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            objEmail.To = toEmail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        /// <summary>
        /// 8
        /// </summary>
        /// <param name="req_Id"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public string Email_FinalApproval_MIS_8(int req_Id, ref string returnMessage)
        {
            var requistionObj = GetRequisitionByID(req_Id);

            string contractorName = "";
            string reqId = "";
            string toEmail = "";
            string ApprovalStatus = "Approved";
            if (requistionObj != null)
            {
                contractorName = requistionObj.CustomerName;
                reqId = req_Id.ToString();
                 
            }

            Email objEmail = new Email();
            objEmail.EmailBody = new StringBuilder().Append("<p>Hi ," +
                                "<br><br>" +
                                contractorName + " bearing REQ ID <b>" + reqId + "</b>  has been successfully approved on KAIZEN. " +
                                " Please get it live in system. " +
                                "<br><br>" + "Regards,<br>Kaizen</p>");
            objEmail.Subject = ApprovalStatus + " - " + contractorName + " - " + reqId;
            objEmail.From = fromEmailAddress;
            string MISEMail = Convert.ToString(WebConfigurationManager.AppSettings["MISEmail"]);
            objEmail.To = MISEMail;
            //objEmail.CC = idString;
            SendEmail sendEmail = new SendEmail();
            sendEmail.SetupEmail(objEmail, ref returnMessage);
            return "";// idString;

        }

        public string GetStageByUserRole(string accountLevel)
        {
            if (accountLevel == "1") return "Initiator";
            else if (accountLevel == "2") return " 1 ";
            else if (accountLevel == "3") return " 2 ";
            else if (accountLevel == "4") return " 3 ";
            else if (accountLevel == "5") return " 4 ";
            else return "";
        }

        public Requisition GetRequisitionByID(int requisitionId)
        {
            using (UFSEntitiess context = new DAL.UFSEntitiess())
            {
                var requistion = context.Requisitions.Include("RequisitionApprovalStatusDetails").Where(a => a.RequisitionId == requisitionId).FirstOrDefault();
                return requistion;
            }
        }

    }
    public class Email
    {
        public StringBuilder EmailBody { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
    }
    public class SendEmail
    {
        public object SetupEmail(Email email, ref string errorMessage)
        {
            string log = string.Empty;

            try
            {
                bool IsUsingSendGridAPI = Convert.ToBoolean(WebConfigurationManager.AppSettings["IsUsingSendGridAPI"]);

                if (email != null || email.To != "")
                {
                    if (email.To.Contains(";"))
                    {
                        email.To = FormatMuntipleEmailAddresses(email.To);
                    }

                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(email.From, email.Subject);
                    mail.To.Add(email.To);
                    if (email.CC != null && email.CC != "") mail.CC.Add(email.CC);
                    mail.Subject = email.Subject;
                    mail.Body = email.EmailBody.ToString();
                    mail.IsBodyHtml = true;

                    if (IsUsingSendGridAPI == false)
                    {
                        return SendEmailSMTP(mail);
                    }
                    else
                    {
                        //Execute(mail).Wait();
                        var task = Task.Run(async () => await Execute(mail));
                        //===========run synchronously
                        //var task2 = Task.Run(  () =>   Execute(mail));
                        return true;
                    }
                }
                return "Mail Empty";
            }
            catch (Exception ex)
            {
                errorMessage = "SetupEmail " + ex.Message + Environment.NewLine + ex.StackTrace + log;// + Environment.NewLine + ex.InnerException != null ? ex.InnerException.Message : "";
                return false;
            }
        }

        static async Task Execute(MailMessage mail)
        {
            #region initParam
            List<EmailAddress> lstEmail = new List<EmailAddress>();
            List<EmailAddress> lstEmailTo = new List<EmailAddress>();
            SendGridMessage msg = null;

            var apiKey = "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";
            apiKey = WebConfigurationManager.AppSettings["SendGridAPI"].ToString();
            var client = new SendGridClient(apiKey);
            #endregion

            #region mail object setup
            var from = new EmailAddress(mail.From.ToString());
            var subject = mail.Subject;
            var to = new EmailAddress(mail.To.ToString());
            var plainTextContent = string.Empty; // mail.Body;
            var htmlContent = mail.Body;
            #endregion

            #region setup Email To object
            List<string> strToList = mail.To.ToString().Split(',').ToList();
            if (strToList.Count > 1)
            {
                foreach (string str in strToList)
                {
                    lstEmailTo.Add(new EmailAddress(str));
                }

                msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, lstEmailTo, subject, plainTextContent, htmlContent);
            }
            else
            {
                msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            }
            #endregion

            #region setup Email cc object
            List<string> strLIst = mail.CC.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (strLIst.Count > 0)
            {
                foreach (string str in strLIst)
                {
                    lstEmail.Add(new EmailAddress(str));
                }
                msg.AddCcs(lstEmail);
            }
            #endregion

            #region final sent
            var response = await client.SendEmailAsync(msg);
            var temp123 = response.StatusCode;
            //in case of failure there is a portal of sendsgrid to check failure email
            //logs can be writes to check failure email, check response.StatusCode and write log in case for failure email //future change
            #endregion
        }
        public object SendEmailSMTP(MailMessage mail)
        {
            try
            {
                SmtpSection secObj = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                var client = new SmtpClient(secObj.Network.Host, secObj.Network.Port);
                // Pass SMTP credentials
                client.Credentials =
                new NetworkCredential(secObj.Network.UserName, secObj.Network.Password);
                // Enable SSL encryption
                client.EnableSsl = true;
                // Try to send the message. Show status in console.
                client.Send(mail);
                //var cnnString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                //var cmds = "INSERT INTO [csddba].[EMAILEXCEPTION] (  [EMESG], [IMESG], [INPUTUSER], [INPUTDATE] )" +
                //                                  " VALUES (@EMESG , @IMESG, @INPUTUSER, @INPUTDATE)";
                //using (SqlConnection cnn = new SqlConnection(cnnString))
                //{
                //    using (SqlCommand cmd = new SqlCommand(cmds, cnn))
                //    {
                //        cmd.Parameters.AddWithValue("@EMESG", "EMAIL SENT = true");
                //        cmd.Parameters.AddWithValue("@IMESG", mail.Subject);
                //        cmd.Parameters.AddWithValue("@INPUTUSER", HttpContext.Current.Session["CurrentUser"].ToString());
                //        cmd.Parameters.AddWithValue("@INPUTDATE", DateTime.UtcNow.AddHours(5));

                //        cnn.Open();
                //        cmd.ExecuteNonQuery();
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                //var cnnString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                //var cmds = "INSERT INTO [csddba].[EMAILEXCEPTION] (  [EMESG], [IMESG], [INPUTUSER], [INPUTDATE] )" +
                //                                  " VALUES (@EMESG , @IMESG, @INPUTUSER, @INPUTDATE)";
                //using (SqlConnection cnn = new SqlConnection(cnnString))
                //{
                //    using (SqlCommand cmd = new SqlCommand(cmds, cnn))
                //    {
                //        cmd.Parameters.AddWithValue("@EMESG", ex.Message);
                //        cmd.Parameters.AddWithValue("@IMESG", GetInnerException(ex));
                //        cmd.Parameters.AddWithValue("@INPUTUSER", HttpContext.Current.Session["CurrentUser"].ToString());
                //        cmd.Parameters.AddWithValue("@INPUTDATE", DateTime.UtcNow.AddHours(5));

                //        cnn.Open();
                //        cmd.ExecuteNonQuery();
                //    }
                //}

                return false;
            }
        }
        public static string FormatMuntipleEmailAddresses(string emailAddresses)
        {
            var delimiters = new[] { ',', ';' };

            var addresses = emailAddresses.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(",", addresses);
        }
    }
}