using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Stavka
    {
        [Key]
        public int IdStavke { get; set; }
        public List<TipKarte> ListaKarti { get; set; } //lista prodatih
        public Cenovnik Cenovnik { get; set; }

        public TipKarte TipKarte { get; set; }
        public double Cena { get; set; }
    }
}