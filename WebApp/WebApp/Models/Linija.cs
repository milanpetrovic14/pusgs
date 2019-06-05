using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Linija
    {
        [Key]
        public int IdLinije { get; set; }
        public string ImeLinije { get; set; }
        public List<Stanica> Stanice { get; set; }
        //public DateTime VremePolaskaA { get; set; }
        //public DateTime VremePolaskaB { get; set; }
    }
}