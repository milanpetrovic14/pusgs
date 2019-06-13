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
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork) {

            this.unitOfWork = unitOfWork;
        }

        [Route("PostProduct")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostProduct(ProductBindingModel prodIM)
        {

            var prod = new Product() { Description = prodIM.Description };

            unitOfWork.Product.Add(prod);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
