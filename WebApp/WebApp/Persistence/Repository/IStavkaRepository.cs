using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public interface IStavkaRepository : IRepository<Stavka, int>
    {
        IEnumerable<Stavka> GetAllStavkaForSinglePage(int pageIndex, int pageSize);
    }
}
