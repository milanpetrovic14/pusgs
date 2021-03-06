﻿using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/RedVoznje")]
    public class RedVoznjeController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public RedVoznjeController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostRedVoznje")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostRedVoznje(RedVoznjeBindingModel redIM)
        {

            var red = new RedVoznje() { Dan = redIM.Dan, Linije = redIM.Linije, ListaPolazaka = redIM.ListaPolazaka };

            unitOfWork.RedVoznje.Add(red);
            unitOfWork.Complete();

            return Ok();
        }        
    }
}
