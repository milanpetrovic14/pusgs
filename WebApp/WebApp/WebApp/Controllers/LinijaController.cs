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

            //return CreatedAtRoute("DefaultApi", new { id = lin.IdLinije }, lin);

            return Ok();
        }

        // GET: api/Linija
        [AllowAnonymous]
        [ResponseType(typeof(List<Linija>))]
        [Route("GetLinije")]
        public IEnumerable<Linija> GetLines()
        {
            List<Linija> linije = unitOfWork.Linija.GetAll().ToList();
            return unitOfWork.Linija.GetAll();
        }

        // GET: api/Linija/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult GetLine(int id)
        {
            Linija line = unitOfWork.Linija.Get(id);
            if (line == null)
            {
                return NotFound();
            }

            return Ok(line);
        }

        // PUT: api/Linija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLine(int id, Linija lin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lin.IdLinije)
            {
                return BadRequest();
            }



            try
            {
                unitOfWork.Linija.Update(lin);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineExists(id))
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

        // DELETE: api/Linija/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult DeleteLine(int id)
        {
            Linija line = unitOfWork.Linija.Get(id);
            if (line == null)
            {
                return NotFound();
            }

            unitOfWork.Linija.Remove(line);
            unitOfWork.Complete();

            return Ok(line);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineExists(int id)
        {
            return unitOfWork.Linija.Find(e => e.IdLinije == id).Count() > 0;
        }
    }
}
