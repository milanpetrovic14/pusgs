using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public interface IRedVoznjeRepozitorijum : IRepository<RedVoznje, int>
    {
        IEnumerable<RedVoznje> GetAllRedVoznjeForSinglePage(int pageIndex, int pageSize);

    }
}
