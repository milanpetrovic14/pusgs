﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> GetAllProductForSinglePage(int pageIndex, int pageSize);
    }
}
