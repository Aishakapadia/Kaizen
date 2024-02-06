using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace UFS_Application.BAL
{
    public class OracleExtract
    {


        public List<Pop_Code> GetPopCodes()
        {
            List<Pop_Code> lstPopCode = new List<Pop_Code>();
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OracleDb"].ToString();
                conn.Open();
                string query = "select distinct  distributor, popCode, name From np_stg_pop where update_flag = '1' and distributor in (" +
                              "'15186886','15347655','15347679','15363059','15437248','15142470','15264569','15288707','15329316','15341018'," +
                              "'15347654','15355560','15385865','50250357','50250365','15382627','50250359','50250360','50251276','15385520','15424461','15191984'," +
                              "'15265875','50250362','50250363','15103005','15213345','15228080','15329808','15415165','15437247','15467967','15468637','50250364','50250367') "+
                              " Union "+
                              " select 'haris traders' as distributor , 'C0100438502' as popCode, 'haris traders' name From np_stg_pop";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int loop = 0; loop < dt.Rows.Count; loop++)
                {
                    lstPopCode.Add(new Pop_Code() { PopCodeId = dt.Rows[loop]["popCode"].ToString(), PopCodeName = dt.Rows[loop]["popCode"].ToString() });
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception exx)
            {
                string message = exx.Message;
                //throw;
            }
            return lstPopCode;
        }
        public List<Sku_Detrail> GetSku_Detrails()
        {
            List<Sku_Detrail> lstSku_Detrail = new List<Sku_Detrail>();
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["OracleDb"].ToString();
                conn.Open();
                string query = "select sku, ldesc from sku where prod5 in ('3G0611394','310990E85','310363E85','310278013','3G0611389','3G0611405','310363013','310366013','3G0611393','3G0611400','310990011','310990511','310985511','310261013','310366D47','310368D47','310364D47','31020N013','310279013')";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int loop = 0; loop < dt.Rows.Count; loop++)
                {
                    lstSku_Detrail.Add(new Sku_Detrail() { Sku_DetrailName = dt.Rows[loop]["sku"].ToString(), Sku_DetrailId = dt.Rows[loop]["sku"].ToString() });
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception exx)
            {
                string message = exx.Message;
               // throw;
            }
            return lstSku_Detrail;
        }
        //public List<Product> GetProducts()
        //{
        //    List<Product> lstProducts = new List<Product>();
        //    lstProducts.Add(new Product() { ProductNameId = "Product1", Product_Name = "Product1" });
        //    lstProducts.Add(new Product() { ProductNameId = "Product2", Product_Name = "Product2" });
        //    lstProducts.Add(new Product() { ProductNameId = "Product3", Product_Name = "Product3" });
        //    lstProducts.Add(new Product() { ProductNameId = "Product4", Product_Name = "Product4" });
        //    lstProducts.Add(new Product() { ProductNameId = "Product5", Product_Name = "Product5" });
        //    return lstProducts;
        //}
    }
    public class Pop_Code
    {
        public string PopCodeId { get; set; }
        public string PopCodeName { get; set; }
    }
    public class Sku_Detrail
    {
        public string Sku_DetrailId { get; set; }
        public string Sku_DetrailName { get; set; }
    }
    //public class Product
    //{
    //    public string ProductNameId { get; set; }
    //    public string Product_Name { get; set; }
    //}

}