using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public ProductRepository(DbContext contex) : base(contex)
        {

        }
        public IEnumerable<Product> GetAllProductForSinglePage(int pageIndex, int pageSize)
        {

            //throw new NotImplementedException();

            return AppDbContext.Products.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}