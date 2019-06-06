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
    [RoutePrefix("api/Stavka")]
    public class StavkaController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public StavkaController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostStavka")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostStavka(StavkaBindingModel stavkaIM)
        {

            var stavka = new Stavka() { Cena = stavkaIM.Cena, Cenovnik = stavkaIM.Cenovnik, ListaKarti = stavkaIM.ListaKarti, TipKarte = stavkaIM.TipKarte };

            unitOfWork.Stavka.Add(stavka);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
