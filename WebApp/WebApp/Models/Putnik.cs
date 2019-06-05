using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Putnik : RegistrovaniKorisnik
    {
        public DateTime DatumRodjenja { get; set; }

        public TipPutnika Tip { get; set; }
        public List<Karta> KupljeneKarte { get; set; }
        public string Dokument {get; set;}
    }
}