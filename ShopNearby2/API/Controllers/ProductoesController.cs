using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BEUShopNearby2;
using BEUShopNearby2.Transactions;

namespace API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductoesController : ApiController
    {

        public IHttpActionResult Post(Producto Producto)
        {
            try
            {
                ProductoBLL.Create(Producto);
                return Content(HttpStatusCode.Created, "Producto creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                List<Producto> todos = ProductoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Producto Producto)
        {
            try
            {
                ProductoBLL.Update(Producto);
                return Content(HttpStatusCode.OK, "Producto actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Producto result = ProductoBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Get(int idTienda, int idPropietario)
        {
            try
            {
                List<Producto> todos = ProductoBLL.List(idTienda, idPropietario);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }




        public IHttpActionResult Delete(int id)
        {
            try
            {
                ProductoBLL.Delete(id);
                return Ok("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}