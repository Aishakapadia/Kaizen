using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UFS_Application.BAL;
using UFS_Application.DAL;

namespace UFS_Application.App_class
{
    public class MiscellaneousOperation
    {
        public void fillAccountType(ref DropDownList ddl)
        {
            ddl.DataSource = new AccountTypeRepository().GetAllAccounTypes();
            ddl.DataTextField = "AccountTitle";
            ddl.DataValueField = "AccountTypeId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void fillAllRegions(ref DropDownList ddl)
        {
            ddl.DataSource = new RegionRepository().GetAllRegions();
            ddl.DataTextField = "RegionName";
            ddl.DataValueField = "RegionId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void fillCompanies(ref DropDownList ddl)
        {
            ddl.DataSource = new CompanyRepository().GetAllCompany();
            ddl.DataTextField = "CompanyName";
            ddl.DataValueField = "CompanyId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void fillFunction(ref DropDownList ddl)
        {
            ddl.DataSource = new FunctionRepository().GetAllFunction();
            ddl.DataTextField = "FunctionName";
            ddl.DataValueField = "FunctionId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void fillGeography(ref DropDownList ddl)
        {
            Dictionary<string, string> lstgeography = new Dictionary<string, string>();
            lstgeography.Add("NORTH", "NORTH");
            lstgeography.Add("SOUTH", "SOUTH");
            lstgeography.Add("CENTRAL", "CENTRAL");
            lstgeography.Add("NATIONAL", "NATIONAL");
            ddl.DataSource = lstgeography;
            ddl.DataTextField = "Value";
            ddl.DataValueField = "Key";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }

        public void GetAllProductName(ref DropDownList ddl)
        {
            // ProductRepository productRepository = new ProductRepository();
            List<Product> lstProduct = null;// productRepository.GetAllProducts();
            ddl.DataSource = lstProduct;
            ddl.DataTextField = "ProductName";
            ddl.DataValueField = "ProductId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }
        public void GetAllProductByCompanyId(ref DropDownList ddl, int companyId)
        {
            ProductRepository productRepository = new ProductRepository();
            List<Product> lstProduct = productRepository.GetAllProductByCompanyId(companyId);
            ddl.DataSource = lstProduct;
            ddl.DataTextField = "ProductName";
            ddl.DataValueField = "ProductId";
            ddl.DataBind();
            addSelectInDropdown(ref ddl);
        }



        public void GetGridViewFilter(ref DropDownList ddl)
        {
            Dictionary<string, string> lstgeography = new Dictionary<string, string>();
            lstgeography.Add("-1", "All");
            lstgeography.Add("0", "Created");
            lstgeography.Add("1", "Submitted");
            lstgeography.Add("2", "Reject");
            lstgeography.Add("3", "Approved");
            lstgeography.Add("4", "Terminated");
            ddl.DataSource = lstgeography;
            ddl.DataTextField = "Value";
            ddl.DataValueField = "Key";
            ddl.DataBind();

        }


        public void addSelectInDropdown(ref DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select", "-1")); //updated code
        }
    }
}