using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;
using UFS_Application.BAL;

namespace UFS_Application.Forms
{
    public partial class ChangePassword :   BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void lbtnSummary_Click(object sender, EventArgs e)
        {
            ReportRepository reportRepository = new BAL.ReportRepository();
            var lst = reportRepository.DashBoard_GetSummary();
            DataTable dt = lst.ToDataTable();
            dt.ExportExcel("Summary");
        }

        public void ChangeUserPassword(object sender, EventArgs e)
        {
            UserRepository userRepository = new BAL.UserRepository();
            userRepository.UpdatePassword(formToObject());
        }


    }
}