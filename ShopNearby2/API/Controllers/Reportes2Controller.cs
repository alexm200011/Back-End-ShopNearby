using BEUShopNearby2;
using BEUShopNearby2.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class Reportes2Controller : ApiController
    {
        [Route("reports2")]
        [ResponseType(typeof(rptPropietarioTienda_Result))]
        public IHttpActionResult GetReportes(int tiendas)
        {
            List<rptPropietarioTienda_Result> user = Reporte2BLL.Get(tiendas);

            /*if (user == null)
            {
                return Content(HttpStatusCode.OK, user);
            }*/
            return Content(HttpStatusCode.OK, user);
        }
    }
}
