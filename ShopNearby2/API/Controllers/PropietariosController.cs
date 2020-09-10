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

    
    public class PropietariosController : ApiController
    {

        public IHttpActionResult Post(Propietario Propietario)
        {
            try
            {
                PropietarioBLL.Create(Propietario);
                return Content(HttpStatusCode.Created, "Propietario creado correctamente");
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
                List<Propietario> todos = PropietarioBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Propietario Propietario)
        {
            try
            {
                PropietarioBLL.Update(Propietario);
                return Content(HttpStatusCode.OK, "Propietario actualizado correctamente");

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
                Propietario result = PropietarioBLL.Get(id);
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

        public IHttpActionResult Delete(int id)
        {
            List<Tienda> lista_tiendas = TiendaBLL.List();
            try
            {
                foreach (var tienda in lista_tiendas)
                {
                    if (tienda.idPropietario == id)
                    {
                        TiendaBLL.Delete(tienda.idTienda);
                    }
                }   
                PropietarioBLL.Delete(id);
               return Ok("Propietario eliminado correctamente");
                
             }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}