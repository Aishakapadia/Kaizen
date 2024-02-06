using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;
using UFS_Application.BAL;
using UFS_Application.DAL;
using EncDecUtil;



namespace UFS_Application
{
    public partial class SignIn : System.Web.UI.Page
    {
        public string heading = "";
        public string message = "";
        public string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session[App_class.MisOp.SessionNames.S_User.ToString()] = FillUserForSession();
            // Response.Redirect("Forms/RequisitionMgmt.aspx");
        }
        public App_class.UserSession FillUserForSession(User user)
        {
            UserSession usersession = new UserSession();
            usersession.emailAddress = "emailAddress";
            usersession.userid = user.UserId;
            usersession.userName = user.UserName;
            usersession.AccountTye = user.AccountType.AccountTitle;
            usersession.AccountLevel = user.AccountType.AccountLevel.Value;
            usersession.AccountTyeId = user.AccountType.AccountTypeId;
            usersession.FirstName = user.FirstName;
            usersession.RegionId = user.RegionId;
            return usersession;



            //UserSession usersession = new UserSession();
            //usersession.emailAddress = "1";
            //usersession.userid = 7;
            //usersession.userName = "7";
            //usersession.AccountTye = "GSM";
            //usersession.AccountLevel = 2;
            //usersession.AccountTyeId = 3;
            //usersession.FirstName = "1";
            //usersession.RegionId = 2;
            //return usersession;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //    if (userName.ToUpper() != txtUsername.Text)
            //    {
            //        heading = "In valid Credentials/Active Directory!";
            //        message = "Window user does not match";
            //        type = "error";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            //        return;
            //    }
            //}
            //catch (Exception exx)
            //{
            //}
            string name = txtUsername.Text;
            string password = txtPassword.Text;
            password = EncDecCls.EncryptData64(password);
            var result = new UserRepository().CheckPassword(name, password);
            if(result == true)
            {
                var userObj = new UserRepository().GetUserByUserNameAndPassword(name, password);
                if (userObj != null)
                {
                    if (!userObj.IsActive)
                    {
                        heading = "In-Active User!";
                        message = "In-Active user.";
                        type = "error";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                    }
                    else
                    {
                        Session[App_class.MisOp.SessionNames.S_User.ToString()] = FillUserForSession(userObj);
                        Response.Redirect("Forms/Home.aspx");
                    }
                }
            }
            //var result = ValidateCredentials(txtUsername.Text, txtPassword.Text);
            //else
            //{
            //    heading = "In valid Credentials!";
            //    message = "The username and password does not exists in the database. Please enter valid credentials.";
            //    type = "error";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            //}
            //}

            //if (!result)
            //{

            //    heading = "In valid Credentials/Active Directory!";
            //    message = "The username and password does not exists in the Active directory. Please enter valid credentials.";
            //    type = "error";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            //    return;
            //}
            //else
            //{
            //    var userObj = new UserRepository().GetUserByUserNameAndPassword(txtUsername.Text, txtPassword.Text);
            //    if (userObj != null)
            //    {
            //        if (!userObj.IsActive)
            //        {
            //            heading = "In-Active User!";
            //            message = "In-Active user.";
            //            type = "error";
            //            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            //        }
            //        else
            //        {
            //            Session[App_class.MisOp.SessionNames.S_User.ToString()] = FillUserForSession(userObj);
            //            Response.Redirect("Forms/Home.aspx");
            //        }
            //    }
            //    else
            //    {
            //        heading = "In valid Credentials!";
            //        message = "The username and password does not exists in the database. Please enter valid credentials.";
            //        type = "error";
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            //    }
            //}
            else
            {
                heading = "In valid Credentials!";
                message = "The username and password does not exists in the database. Please enter valid credentials.";
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, "S1"))
                {

                    return context.ValidateCredentials(username, password, ContextOptions.Negotiate);
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}