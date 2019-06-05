using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public abstract class RegistrovaniKorisnik
    {
        
        public string Email {get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Key]
        public string KorisnickoIme { get; set; }
    }
}