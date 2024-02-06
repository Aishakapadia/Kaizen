using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.BAL;
using UFS_Application.DAL;


namespace UFS_Application.Forms
{
    public partial class Home : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                fillDashBoard();
            }
        }
        public void fillDashBoard()
        {
            Categorized_DashBaord_Result cbr = new Categorized_DashBaord_Result();
            var result = new SPRepository().GetCategorized_DashBaord_Result();
           
            if (result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.CENTRAL.ToString()).ToList().Count == 0)
            {
                result.Insert(0,new Categorized_DashBaord_Result()
                {
                    Categorization = App_class.MisOp.enum_regions.CENTRAL.ToString(),
                    MaxGSV = 0,
                    MaxTTS = 0,
                    MinGSV = 0,
                    MinTTS = 0,
                    NoOfContract = 0

                });
            }
            if (result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.SOUTH.ToString()).ToList().Count == 0)
            {
                result.Insert(1, new Categorized_DashBaord_Result()
                {
                    Categorization = App_class.MisOp.enum_regions.SOUTH.ToString(),
                    MaxGSV = 0,
                    MaxTTS = 0,
                    MinGSV = 0,
                    MinTTS = 0,
                    NoOfContract = 0

                });
            }
            if (result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.NORTH.ToString()).ToList().Count == 0)
            {
                result.Insert(2, new Categorized_DashBaord_Result()
                {
                    Categorization = App_class.MisOp.enum_regions.NORTH.ToString(),
                    MaxGSV = 0,
                    MaxTTS = 0,
                    MinGSV = 0,
                    MinTTS = 0,
                    NoOfContract = 0

                });
            }

            if (result.Where(a => a.Categorization.ToUpper() == "FOODS-9860").ToList().Count == 0)
            {
                result.Insert(3, new Categorized_DashBaord_Result()
                {
                    Categorization = "FOODS-9860",
                    MaxGSV = 0,
                    MaxTTS = 0,
                    MinGSV = 0,
                    MinTTS = 0,
                    NoOfContract = 0

                });
            }
            if (result.Where(a => a.Categorization.ToUpper() == "TEA-1714").ToList().Count == 0)
            {
                result.Insert(4, new Categorized_DashBaord_Result()
                {
                    Categorization = "TEA-1714",
                    MaxGSV = 0,
                    MaxTTS = 0,
                    MinGSV = 0,
                    MinTTS = 0,
                    NoOfContract = 0

                });
            }



            var result_Sum = result.Where(a =>
              a.Categorization.ToUpper() == App_class.MisOp.enum_regions.CENTRAL.ToString()
           || a.Categorization.ToUpper() == App_class.MisOp.enum_regions.SOUTH.ToString()
           || a.Categorization.ToUpper() == App_class.MisOp.enum_regions.NORTH.ToString()).ToList();


            foreach (var item in result_Sum)
            {
                cbr.Categorization = "UFS";
                cbr.MinGSV = (cbr.MinGSV == null ? 0 : cbr.MinGSV) + item.MinGSV;
                cbr.MaxGSV = (cbr.MaxGSV == null ? 0 : cbr.MaxGSV) + item.MaxGSV;
                cbr.MinTTS = (cbr.MinTTS == null ? 0 : cbr.MinTTS) + item.MinTTS;
                cbr.MaxTTS = (cbr.MaxTTS == null ? 0 : cbr.MaxTTS) + item.MaxTTS;
                cbr.NoOfContract = (cbr.NoOfContract == null ? 0 : cbr.NoOfContract) + item.NoOfContract;
            }
            result.Add(cbr);
            //======================================
            var finalResult = result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.CENTRAL.ToString()).ToList();
            finalResult.AddRange(result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.SOUTH.ToString()).ToList());
            finalResult.AddRange(result.Where(a => a.Categorization.ToUpper() == App_class.MisOp.enum_regions.NORTH.ToString()).ToList());
            finalResult.AddRange(result.Where(a => a.Categorization.ToUpper() == "FOODS-9860").ToList());
            finalResult.AddRange(result.Where(a => a.Categorization.ToUpper() == "TEA-1714").ToList());
            finalResult.AddRange(result.Where(a => a.Categorization.ToUpper() == "UFS").ToList());

            rptrChart.DataSource = finalResult;
            rptrChart.DataBind();
        }
    }

}