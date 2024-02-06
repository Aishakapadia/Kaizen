using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class SPRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public SPRepository()
        {
            context = new UFSEntitiess();
        }
        public List<Categorized_DashBaord_Result> GetCategorized_DashBaord_Result()
        {
            return context.Categorized_DashBaord().ToList();
        }
    }
}