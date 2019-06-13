using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RedVoznje
    {
        [Key]
        public int IdRedaVoznje { get; set; }
        public Linija Linije {get; set;}
        public TipDana Dan { get; set; }
        public List<DateTime> ListaPolazaka { get; set; }
    }
}