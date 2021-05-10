using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matsyshenV_ISIT420_HW4.Controllers
{
    public class StoreController : ApiController
    {
        NodeOrders500Entities myNodeOrdersDB = new NodeOrders500Entities();

        public IEnumerable<string> GetStores()
        {
            var result =
                (from stores in myNodeOrdersDB.Orders
                 select stores.StoreTable.City)
                 .Distinct()
                 .AsEnumerable();

            return result;
        }
    }
}
