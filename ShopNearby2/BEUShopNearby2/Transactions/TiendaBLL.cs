using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUShopNearby2.Transactions
{
    public class TiendaBLL
    {
        public static void Create(Tienda a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Tienda.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Tienda Get(int? id)
        {
            Entities db = new Entities();
            return db.Tienda.Find(id);
        }

    // Busqueda para el Incognito
        public static List<Tienda> List(int? idCiudad, int idPropietario)
        {
            Entities db = new Entities();
            return db.Tienda.Where(x => x.idCiudad.ToString().Contains(idCiudad.ToString())).ToList();
        }

        // Busqueda para el Usuario Logueado
        public static List<Tienda> List2(int? idCiudad, int idPropietario)
        {
            Entities db = new Entities();
            return db.Tienda.Where(x => x.idPropietario.ToString().Contains(idPropietario.ToString())).ToList();
        }


        public static List<Tienda> List(string Nombre)
        {
            Entities db = new Entities();
            return db.Tienda.Where(x => x.Nombre.Contains(Nombre)).ToList();
        }


        public static void Update(Tienda Tienda)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Tienda.Attach(Tienda);
                        db.Entry(Tienda).State = System.Data.Entity.EntityState.Unchanged;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Tienda Tienda = db.Tienda.Find(id);
                        db.Entry(Tienda).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public static List<Tienda> List()
        {
            Entities db = new Entities();
            return db.Tienda.ToList();
        }
    }
}

