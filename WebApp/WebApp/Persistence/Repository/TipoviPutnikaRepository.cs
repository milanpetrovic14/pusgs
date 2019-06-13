using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class TipoviPutnikaRepository : Repository<TipPutnika, int>, ITipoviPutnikaRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }
        public TipoviPutnikaRepository(DbContext contex) : base(contex)
        {

        }        

        public IEnumerable<TipPutnika> GetAllProductForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.TipoviPutnika.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        }
    }
}