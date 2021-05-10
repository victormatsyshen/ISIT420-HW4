using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace matsyshenV_ISIT420_HW4.Controllers
{
    public class SalesPersonController : ApiController
    {
        NodeOrders500Entities myNodeOrdersDB = new NodeOrders500Entities();

        public IEnumerable<string> GetEmployees()
        {
            var result =
               (from sales in myNodeOrdersDB.Orders
                select sales.SalesPersonTable.FirstName + " " + sales.SalesPersonTable.LastName)
                .Distinct()
                .AsEnumerable();

            return result;
        }
    }
}
