using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class CenovnikRepository : Repository<Cenovnik, int>, ICenovnikRepozitorijum
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public CenovnikRepository(DbContext contex) : base(contex)
        {

        }        

        public IEnumerable<Cenovnik> GetAllCenovnikForSinglePage(int pageIndex, int pageSize)
        {
            return AppDbContext.Cenovnici.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}