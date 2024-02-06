using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFS_Application.App_class
{
    [Serializable]
    public class RequisitionCls
    {
        public int RequisitionDetailId { get; set; }
        public string ProductName { get; set; }
        public string SKUCode { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<int> MinQtyMonthCases { get; set; }
        public Nullable<int> MaxQtyMonthCases { get; set; }
    }
}