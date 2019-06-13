using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
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

        // GET: api/Pricelists/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult GetPricelist(int id)
        {
            Cenovnik pricelist = unitOfWork.Cenovnik.Get(id);
            if (pricelist == null)
            {
                return NotFound();
            }

            return Ok(pricelist);
        }

        // PUT: api/Pricelists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPricelist(int id, Cenovnik pricelist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pricelist.Id)
            {
                return BadRequest();
            }



            try
            {
                unitOfWork.Cenovnik.Update(pricelist);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricelistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Pricelists/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult DeletePricelist(int id)
        {
            Cenovnik pricelist = unitOfWork.Cenovnik.Get(id);
            if (pricelist == null)
            {
                return NotFound();
            }

            unitOfWork.Cenovnik.Remove(pricelist);
            unitOfWork.Complete();

            return Ok(pricelist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PricelistExists(int id)
        {
            return unitOfWork.Cenovnik.Find(e => e.Id == id).Count() > 0;
        }
    }
}
