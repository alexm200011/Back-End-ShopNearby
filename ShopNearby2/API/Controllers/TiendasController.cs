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


    public class TiendasController : ApiController
    {
        
        public IHttpActionResult Post(Tienda Tienda)
        {
            try
            {
                TiendaBLL.Create(Tienda);
                return Content(HttpStatusCode.Created, "Tienda creado correctamente");
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
                List<Tienda> todos = TiendaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put(Tienda Tienda)
        {
            try
            {
                TiendaBLL.Update(Tienda);
                return Content(HttpStatusCode.OK, "Tienda actualizado correctamente");

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
                Tienda result = TiendaBLL.Get(id);
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

        public IHttpActionResult Get(string Nombre)
        {
            try
            {
                List<Tienda> todos = TiendaBLL.List(Nombre);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        //Get desde el cliente
        public IHttpActionResult Get(int idCiudad, int idPropietario)
        {
            
            try
            {
                List<Tienda> todos = TiendaBLL.List(idCiudad, idPropietario);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }


        public IHttpActionResult Get(int idCiudad, int idPropietario, int valor3)
        {
            try
            {
                List<Tienda> todos = TiendaBLL.List2(idCiudad, idPropietario);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }




        public IHttpActionResult Delete(int id)
        {
            List<Producto> lista_productos = ProductoBLL.List();
    
            try
            {
                foreach (var producto in lista_productos)
                {
                    if (producto.idTienda == id)
                    {
                        ProductoBLL.Delete(producto.idProducto);
                    }
                }
                TiendaBLL.Delete(id);
                return Ok("Tienda eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}