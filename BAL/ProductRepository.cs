using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFS_Application.DAL;

namespace UFS_Application.BAL
{
    public class ProductRepository
    {
        public UFSEntitiess context;
        bool result = false;
        public ProductRepository()
        {
            context = new UFSEntitiess();
        }
        public List<Product> GetAllProducts()
        {
            return context.Products.Where(a => a.IsActive == true).ToList();
        }
        public Product GetProductByProductId(int productId)
        {
            return context.Products.Where(a => a.ProductId == productId).FirstOrDefault();
        }
        public List<Product> GetAllProductByCompanyId(int companyId)
        {
            return context.Products.Where(a => a.CompanyId == companyId).ToList();
        }
    }
}