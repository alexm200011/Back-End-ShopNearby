using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUShopNearby2.Transactions
{
    public class Reporte2BLL
    {
        public static List<rptPropietarioTienda_Result> Get(int? tiendas)
        {
            Entities db = new Entities();
            return db.rptPropietarioTienda(tiendas).ToList();

        }

    }

}