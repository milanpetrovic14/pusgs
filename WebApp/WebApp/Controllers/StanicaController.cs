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
    [RoutePrefix("api/Stanica")]
    public class StanicaController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public StanicaController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostStanica")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostStanica(StanicaBindingModel stanIM)
        {

            var stan = new Stanica() { NazivStanice = stanIM.NazivStanice, AdresaStanice = stanIM.AdresaStanice };

            unitOfWork.Stanica.Add(stan);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
