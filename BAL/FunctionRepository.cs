using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class FunctionRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public FunctionRepository()
        {
            context = new UFSEntitiess();
        }
        public List<Function> GetAllFunction()
        {
            return context.Functions.Where(a => a.IsActive == true).ToList();
        }
    }
}