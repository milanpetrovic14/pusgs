using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RedVoznjeRepository : Repository<RedVoznje, int>, IRedVoznjeRepozitorijum
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public RedVoznjeRepository(DbContext contex) : base(contex)
        {

        }
        public IEnumerable<RedVoznje> GetAllRedVoznjeForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.RedoviVoznje.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        }
    }
}