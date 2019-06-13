using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipKarte
    {
        //Vremenska,
        //Dnevna,
        //Mesecna,
        //Godisnja
        [Key]
        public string Tip { get; set; }
        //lista stavki
        //id

    }
}