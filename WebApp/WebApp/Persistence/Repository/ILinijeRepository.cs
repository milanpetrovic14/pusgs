using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public interface ILinijeRepository : IRepository<Linija, int>
    {
        IEnumerable<Linija> GetAllLinijaForSinglePage(int pageIndex, int pageSize);

    }
}
