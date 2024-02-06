using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFS_Application.Forms
{
    public class BasePage : System.Web.UI.Page
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (Session[App_class.MisOp.SessionNames.S_User.ToString()] == null)
            {
                Response.Redirect("~/SignIn.aspx", true);
            }
             
        }
    }
}