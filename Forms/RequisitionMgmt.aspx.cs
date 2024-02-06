using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;

namespace UFS_Application.Forms
{
    public partial class RequisitionMgmt : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Session[App_class.MisOp.SessionNames.S_User.ToString()] != null && 
                new SessionHelper().getUserSession().AccountTyeId == Convert.ToInt32(MisOp.AccountTypes.MIS))
            {
                Response.Redirect("~/Forms/Home.aspx");
            }
        }
    }
}