using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class KartaRepository : Repository<Karta, int>, IKartaRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public KartaRepository(DbContext contex) : base(contex)
        {

        }       

        public IEnumerable<Karta> GetAllKartaForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.Karte.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}