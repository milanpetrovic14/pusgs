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
    [RoutePrefix("api/Linija")]
    public class LinijaController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public LinijaController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostLinija")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostLinija(LinijaBindingModel linIM)
        {

            var lin = new Linija() { ImeLinije = linIM.ImeLinije, Stanice = linIM.Stanice };

            unitOfWork.Linija.Add(lin);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
