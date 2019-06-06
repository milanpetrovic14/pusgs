using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApp.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ProductBindingModel {
        [Required]

        [Display(Name = "Description")]
        public string Description { get; set; }

    }

    public class LinijaBindingModel
    {
        [Required]

        [Display(Name = "ImeLinije")]
        public string ImeLinije { get; set; }


        [Display(Name = "Stanice")]

        public List<Stanica> Stanice { get; set; }

    }

    public class StavkaBindingModel
    {
        [Required]

        [Display(Name = "Cena")]
        public double Cena { get; set; }

        [Display(Name = "ListaKarti")]
        public List<TipKarte> ListaKarti { get; set; }

        [Display(Name = "Cenovnik")]
        public Cenovnik Cenovnik { get; set; }

        [Display(Name = "TipKarte")]
        public TipKarte TipKarte { get; set; }

    }

    public class CenovnikBindingModel
    {
        [Required]

        [Display(Name = "Od")]
        public DateTime Od { get; set; }

        [Display(Name = "Do")]
        public DateTime Do { get; set; }

    }

    public class KartaBindingModel
    {
        [Required]

        [Display(Name = "VremeKupovine")]
        public DateTime VremeKupovine { get; set; }
        [Display(Name = "VrstaKarte")]
        public TipKarte VrstaKarte { get; set; }
        [Display(Name = "Stavka")]
        public Stavka Stavka { get; set; }
        [Display(Name = "Putnik")]
        public Putnik Putnik { get; set; }

    }

    public class StanicaBindingModel
    {
        [Required]

        [Display(Name = "NazivStanice")]
        public string NazivStanice { get; set; }
        [Display(Name = "AdresaStanice")]

        public string AdresaStanice { get; set; }

    }
    
    public class RedVoznjeBindingModel
    {
        //[Required]
        [Display(Name = "Linije")]
        public Linija Linije { get; set; }
        [Display(Name = "Dan")]
        public TipDana Dan { get; set; }
        [Display(Name = "ListaPolazaka")]
        public List<DateTime> ListaPolazaka { get; set; }

    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
