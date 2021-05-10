using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matsyshenV_ISIT420_HW4.Controllers
{
    public class StoreSalesController : ApiController
    {
        NodeOrders500Entities myNodeOrdersDB = new NodeOrders500Entities();

        public IHttpActionResult GetStoreSales(string storeCity)
        {
            var result =
                (from order in myNodeOrdersDB.Orders
                 where order.StoreTable.City == storeCity
                 select order.pricePaid)
                 .Sum();

            return Ok(result);
        }
    }
}
