using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public interface ITipoviPutnikaRepository : IRepository<TipPutnika, int>
    {
        IEnumerable<TipPutnika> GetAllProductForSinglePage(int pageIndex, int pageSize);

    }
}
