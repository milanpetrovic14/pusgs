using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Administrator : RegistrovaniKorisnik
    {
        public List<Putnik> ZahteviPutnika { get; set; }
    }
}