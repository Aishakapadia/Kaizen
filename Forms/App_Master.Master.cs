using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;
using UFS_Application.DAL;
using static UFS_Application.App_class.MisOp;

namespace UFS_Application.Forms
{
    public partial class App_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[App_class.MisOp.SessionNames.S_User.ToString()] == null)
            {
                Response.Redirect("~/SignIn.aspx", true);
                
            }
            else
            {
                lblUserName.Text = "Welcome, " + ((App_class.UserSession)Session[App_class.MisOp.SessionNames.S_User.ToString()]).userName;
                
            }

            if (!IsPostBack)
            {
                var user = ((App_class.UserSession)Session[App_class.MisOp.SessionNames.S_User.ToString()]);
                //lblUserName.Text = "Welcome: " + user.userName;
            }
            UserMenu();
        }
        public void UserMenu()
        {
            if (Session[App_class.MisOp.SessionNames.S_User.ToString()] != null && new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(AccountTypes.MIS))
            {
                a_home.Visible = true;
                a_ReportMgmt.Visible = true;
                a_RequisitionMgmt.Visible = false;
                a_UserMgmt.Visible = true;
            }
            else
            {
                a_UserMgmt.Visible = false;
            }

        }



        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/SignIn.aspx");
        }

        protected void lbtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/ChangePassword.aspx");
        }
    }
}