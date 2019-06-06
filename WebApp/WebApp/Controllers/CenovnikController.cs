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
    [RoutePrefix("api/Cenovnik")]
    public class CenovnikController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public CenovnikController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostCenovnik")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostCenovnik(CenovnikBindingModel cenIM)
        {

            var cen = new Cenovnik() { Od = cenIM.Od, Do = cenIM.Do };

            unitOfWork.Cenovnik.Add(cen);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
