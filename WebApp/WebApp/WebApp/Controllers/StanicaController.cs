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

            //return CreatedAtRoute("DefaultApi", new { id = lin.IdLinije }, lin);
            return Ok();
        }

        // GET: api/Stations
        public IEnumerable<Stanica> GetStation()
        {
            return unitOfWork.Stanica.GetAll();
        }

        // GET: api/Stations/5
        [ResponseType(typeof(Stanica))]
        public IHttpActionResult GetStation(int id)
        {
            Stanica station = unitOfWork.Stanica.Get(id);
            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        // PUT: api/Stations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStation(int id, Stanica station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != station.IdStanice)
            {
                return BadRequest();
            }



            try
            {
                unitOfWork.Stanica.Update(station);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // DELETE: api/Stations/5
        [ResponseType(typeof(Stanica))]
        public IHttpActionResult DeleteStation(int id)
        {
            Stanica station = unitOfWork.Stanica.Get(id);
            if (station == null)
            {
                return NotFound();
            }

            unitOfWork.Stanica.Remove(station);
            unitOfWork.Complete();

            return Ok(station);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(int id)
        {
            return unitOfWork.Stanica.Find(e => e.IdStanice == id).Count() > 0;
        }
    }
}
