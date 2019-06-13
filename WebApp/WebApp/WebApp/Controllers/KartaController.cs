using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    //neki frontend, pogodimo bekend i dobojemo jwt
    //jwtom gadjamo kontroler
    [RoutePrefix("api/Karta")]
    public class KartaController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public KartaController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostKarta")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostKarta(KartaBindingModel kartaIM)
        {

            var karta = new Karta() { VremeKupovine = kartaIM.VremeKupovine, /*Putnik = kartaIM.Putnik,*/ Stavka = kartaIM.Stavka, VrstaKarte = kartaIM.VrstaKarte };

            unitOfWork.Karta.Add(karta);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
