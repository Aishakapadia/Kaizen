using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.BAL;

namespace UFS_Application.Forms
{
    public partial class RequisitionAudit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count>0 && Request.QueryString["ReqId"]!=null && Convert.ToInt32(Request.QueryString["ReqId"])>0)
            {
                gv_ReqAudit.DataSource = new RequisitionRepository().GetRequisitionAuditById(Convert.ToInt32(Request.QueryString["ReqId"]));
                gv_ReqAudit.DataBind();
            }

        }
    }
}