using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class StavkaRepository : Repository<Stavka, int>, IStavkaRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }
        public StavkaRepository(DbContext contex) : base(contex)
        {

        }

        public IEnumerable<Stavka> GetAllStavkaForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.Stavke.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}