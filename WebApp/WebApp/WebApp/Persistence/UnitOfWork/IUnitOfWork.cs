using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITipoviPutnikaRepository tipPutnika { get; set; }
        IProductRepository Product { get; set; } //Products
        ILinijeRepository Linija { get; set; }
        IRedVoznjeRepozitorijum RedVoznje { get; set; }
        IStavkaRepository Stavka { get; set; }
        ICenovnikRepozitorijum Cenovnik { get; set; }
        IKartaRepository Karta { get; set; }
        IStanicaRepository Stanica { get; set; }
        int Complete();
    }
}
