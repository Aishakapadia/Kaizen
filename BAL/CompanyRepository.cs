using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class CompanyRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public CompanyRepository()
        {
            context = new UFSEntitiess();
        }
        public List<Company> GetAllCompany()
        {
            return context.Companies.Where(a => a.IsActive == true).ToList();
        }
    }
    public class AccountTypeRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public AccountTypeRepository()
        {
            context = new UFSEntitiess();
        }
        public List<AccountType> GetAllAccounTypes()
        {
            return context.AccountTypes.Where(a => a.IsActive == true).ToList();
        }
    }

    public class RegionRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public RegionRepository()
        {
            context = new UFSEntitiess();
        }
        public List<Region> GetAllRegions()
        {
            return context.Regions.Where(a => a.IsActive == true).ToList();
        }
    }
}