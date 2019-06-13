using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class LinijaRepository : Repository<Linija, int>, ILinijeRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public LinijaRepository(DbContext contex) : base(contex)
        {

        }
        public IEnumerable<Linija> GetAllLinijaForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.Linije.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}