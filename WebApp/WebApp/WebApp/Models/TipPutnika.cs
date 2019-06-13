using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipPutnika
    {
           //Djak,
           //Penzioner,
           //Regularan
           [Key]
           //id
           public string Tip { get; set; }
           public double Koeficijet { get; set; }
           //lista korisnika
           //lista popusta
            
    }
}