using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Karta
    {
        [Key]
        public int IdKarte { get; set; }
        public TipKarte VrstaKarte { get; set; }
    }
}