using API.Models;
using BEUShopNearby2;
using BEUShopNearby2.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Propietario propietario)
        {
            if (propietario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            propietario = PropietarioBLL.ValidateLogin(propietario);
            if (propietario != null)
            {
                return Ok(new
                {
                    user = propietario,
                    token = TokenGenerator.GenerateTokenJwt(propietario)
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

