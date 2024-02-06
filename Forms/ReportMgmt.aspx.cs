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
    public partial class ReportMgmt :   BasePage
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

        protected void lbtnBySK_Click(object sender, EventArgs e)
        {
            ReportRepository reportRepository = new BAL.ReportRepository();
            //var lst = reportRepository.DashBoard_GetBySKU();
            //lst.ForEach(a => a.RequestorComments =
            //System.Text.RegularExpressions.Regex.Replace(a.RequestorComments, @"\t|\n|\r", "")
            //);
            //lst.ForEach(a => a.RequestorComments = a.RequestorComments.Replace(",", " ")            
            //);
            DataTable dt = reportRepository.DashBoard_GetBySKU_dt();
            //string replacement = Regex.Replace(s, @"\t|\n|\r", "");
            //DataTable dt = lst.ToDataTable();
            dt.ExportExcel("BySKU");

        }

        protected void lbtnByCustomer_Click(object sender, EventArgs e)
        {
            ReportRepository reportRepository = new BAL.ReportRepository();
            DataTable dt = reportRepository.DashBoard_GetByCustomer();
            //DataTable dt = lst.ToDataTable();
            dt.ExportExcel("By Customer");
        }


    }
}