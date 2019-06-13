using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
      
        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

        [Dependency]
        public ITipoviPutnikaRepository tipPutnika { get; set; }
        public IProductRepository Product { get; set; }
        public ILinijeRepository Linija { get; set; }
        public IRedVoznjeRepozitorijum RedVoznje { get; set; }
        public IStavkaRepository Stavka { get; set; }
        public ICenovnikRepozitorijum Cenovnik { get; set; }
        public IKartaRepository Karta { get; set; }
        public IStanicaRepository Stanica { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}