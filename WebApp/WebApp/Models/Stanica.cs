using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Stanica
    {
        [Key]
        public int IdStanice { get; set; }
        public string AdresaStanice { get; set; }
        public string NazivStanice { get; set; }
    }
}