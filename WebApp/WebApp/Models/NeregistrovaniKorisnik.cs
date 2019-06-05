using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class NeregistrovaniKorisnik
    {
        [Key]
        public int IdKarteKorisnika { get; set; }
    }
    //lista stavki, stavka(karta)
}