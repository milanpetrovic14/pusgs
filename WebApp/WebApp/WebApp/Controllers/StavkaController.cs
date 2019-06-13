using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    //neki frontend, pogodimo bekend i dobojemo jwt
    //jwtom gadjamo kontroler
    [RoutePrefix("api/Stavka")]
    public class StavkaController : ApiController
    {

        private IUnitOfWork unitOfWork;
        private ApplicationDbContext db = new ApplicationDbContext();


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

            //return CreatedAtRoute("DefaultApi", new { id = priceOfTicket.Id }, priceOfTicket);

            return Ok();
        }

        //[AllowAnonymous]
        //[ResponseType(typeof(float))]
        //[Route("GetKarta/{tip}")]
        //public IHttpActionResult GetKartaCena(string tip)
        //{
        //    List<TypeTicket> karte = unitOfWork.TypeTicketRepository.GetAll().ToList();
        //    PriceOfTicket price = new PriceOfTicket();
        //    float cena = 0;
        //    foreach (TypeTicket k in karte)
        //    {
        //        if (tip == k.Type)
        //        {
        //            price = unitOfWork.PriceOfTicketRepository.Get(k.Id);
        //            cena = price.Price;
        //        }
        //    }

        //    if (karte == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cena);
        //}
        //[Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        //[ResponseType(typeof(string))]
        //[Route("GetKartaKupi2/{tipKarte}/{tipKorisnika}/{user}")]
        //public IHttpActionResult GetKarta(string tipKarte, string tipKorisnika, string user)
        //{

        //    var userStore = new UserStore<ApplicationUser>(db);
        //    var userManager = new UserManager<ApplicationUser>(userStore);

        //    var id = User.Identity.GetUserId();
        //    ApplicationUser u = userManager.FindById(user);

        //    List<Stavka> karte = unitOfWork.Stavka.GetAll().ToList();
        //    Stavka price = new Stavka();
        //    double cena = 0;
        //    string retVal = "";
        //    foreach (Stavka k in karte)
        //    {
        //        k.TipKarte = unitOfWork.TipKarteRepository.Get(k.TypeTicketId);
        //        if (k.TipKarte.Tip == tipKarte)
        //        {
        //            cena = unitOfWork.Stavka.Get(k.IdStavke);
        //            if (tipKorisnika == "student")
        //                cena = cena.Price * 0.8;
        //            if (tipKorisnika == "penzioner")
        //                cena = cena.Price * 0.5;
        //            else
        //                cena = cena.Price;

        //            Karta t = new Karta();
        //            t.CenaKarte = k;
        //            t.PriceOfTicketId = k.Id;
        //            t.Tip = k.TypeTicket.Type;
        //            t.ApplicationUserId = u.Id;
        //            t.ApplicationUser = u;
        //            t.VaziDo = DateTime.UtcNow;
        //            u.Tickets.Add(t);

        //            //t.PriceOfTicket = price;
        //            //u.Tickets.Add(k);
        //        }

        //        retVal += "Uspesno ste kupili " + tipKarte + ", po ceni od : " + cena.ToString() + " din";
        //    }

        //    if (karte == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(retVal);
        //}

        // GET: api/PriceOfTickets
        public IEnumerable<Stavka> GetPriceOfTicket()
        {
            return unitOfWork.Stavka.GetAll();
        }

        // GET: api/PriceOfTickets/5
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult GetPriceOfTicket(int id)
        {
            Stavka stavka = unitOfWork.Stavka.Get(id);
            if (stavka == null)
            {
                return NotFound();
            }

            return Ok(stavka);
        }

        // PUT: api/PriceOfTickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriceOfTicket(int id, Stavka stavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka.IdStavke)
            {
                return BadRequest();
            }



            try
            {
                unitOfWork.Stavka.Update(stavka);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StavkaExists(id))
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

        // DELETE: api/PriceOfTickets/5
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult DeletePriceOfTicket(int id)
        {
            Stavka stavka = unitOfWork.Stavka.Get(id);
            if (stavka == null)
            {
                return NotFound();
            }

            unitOfWork.Stavka.Remove(stavka);
            unitOfWork.Complete();

            return Ok(stavka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StavkaExists(int id)
        {
            return unitOfWork.Stavka.Find(e => e.IdStavke == id).Count() > 0;
        }
    }
}
