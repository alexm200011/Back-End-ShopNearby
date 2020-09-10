using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUShopNearby2.Transactions
{
    public class ReporteBLL
    {
        public static List<rptTiendaProducto_Result> Get(int? productos)
        {
            Entities db = new Entities();
            return db.rptTiendaProducto(productos).ToList();

        }

    }

}