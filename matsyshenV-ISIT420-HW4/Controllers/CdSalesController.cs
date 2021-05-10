using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matsyshenV_ISIT420_HW4.Controllers
{
    public class CdSalesController : ApiController
    {
        NodeOrders500Entities myNodeOrdersDB = new NodeOrders500Entities();
        public IHttpActionResult GetMarkups()
        {
            var result =
                (from order in myNodeOrdersDB.Orders
                 group order by order.StoreTable.City into bStores
                 orderby bStores.Count(x => x.pricePaid > 13) descending
                 select new { City = bStores.Key, Count = bStores.Count(x => x.pricePaid > 13) })
                 .AsEnumerable();

            return Ok(result);
        }
    }
}
