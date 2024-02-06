using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class ReportRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public ReportRepository()
        {
            context = new UFSEntitiess();
        }
        public List<StoredProcedure_RequisitionSummary_Result> DashBoard_GetSummary()
        {
            return context.StoredProcedure_RequisitionSummary().ToList();
        }
        public List<v_RequisitionBySku> DashBoard_GetBySKU()
        {
            return context.v_RequisitionBySku.ToList();
        }
        public DataTable DashBoard_GetByCustomer()
        {
           // return context.V_RequisitionByCustomerWise.ToList();
            DataTable dt = this.ExecuteSQL("SelecT * from V_RequisitionByCustomerWise");
            for (var current = 0; current < dt.Rows.Count; current++)
            {
                dt.Rows[current]["Background"] =
                   System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["Background"].ToString(), @"\t|\n|\r", "");
                dt.Rows[current]["Background"] =
                   System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["Background"].ToString(), ",", " ");
                dt.Rows[current]["RequestorComments"] =
                    System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["RequestorComments"].ToString(), @"\t|\n|\r", "");
                dt.Rows[current]["RequestorComments"] =
                   System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["RequestorComments"].ToString(), ",", " ");
            }
            return dt;
        }
        public DataTable DashBoard_GetBySKU_dt()
        {
            DataTable dt = this.ExecuteSQL("SelecT * from v_RequisitionBySku");
            for (var current = 0; current < dt.Rows.Count; current++)
            {
                dt.Rows[current]["RequestorComments"] =
                    System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["RequestorComments"].ToString(), @"\t|\n|\r", "");
                dt.Rows[current]["RequestorComments"] =
                   System.Text.RegularExpressions.Regex.Replace(dt.Rows[current]["RequestorComments"].ToString(), ",", " ");
            }
            return dt;
        }
        public DataTable ExecuteSQL(string query)
        {
            using (var context = new UFSEntitiess())
            {
                var dt = new DataTable();
                var conn = context.Database.Connection;
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        //  cmd.Parameters.Add(new SqlParameter("jobCardId", 100525));
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    throw;
                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }
                return dt;
            }

        }
    }
}