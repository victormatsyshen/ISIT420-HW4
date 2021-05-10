using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;  // need to add that   

namespace matsyshenV_ISIT420_HW4.Controllers
{
    public class OrdersController : ApiController
    {
        NodeOrders500Entities myDB = new NodeOrders500Entities();

        //// return orders
        //public IEnumerable<Order> GetAllOrders()
        //{
        //    return myDB.Orders;
        //}

        // return stores
        public IEnumerable<string> GetAllStores()
        {
            var result =
                (from stores in myDB.Orders
                 select stores.StoreTable.City).Distinct().AsEnumerable();

            return result;
        }

        // return salesPeople
        public IEnumerable<string> GetAllSalesPeople()
        {
            var result =
               (from sales in myDB.Orders
                select sales.SalesPersonTable.FirstName + " " + sales.SalesPersonTable.LastName).Distinct().AsEnumerable();

            return result;
        }

        // return Markups
        public IHttpActionResult GetMarkups()
        {
            var result =
                (from order in myDB.Orders
                 group order by order.StoreTable.City into bStores
                 orderby bStores.Count(x => x.pricePaid > 13) descending
                 select new { City = bStores.Key, Count = bStores.Count(x => x.pricePaid > 13) }).AsEnumerable();

            return Ok(result);
        }

        // return Employee Sales
        public IHttpActionResult GetEmployeeSales(string employeeName)
        {
            var result =
                (from order in myDB.Orders
                 where (order.SalesPersonTable.FirstName + " " + order.SalesPersonTable.LastName) == employeeName
                 select order.pricePaid).Sum();

            return Ok(result);
        }

        // return Store Sales

        public IHttpActionResult GetStoreSales(string storeCity)
        {
            var result =
                (from order in myDB.Orders
                 where order.StoreTable.City == storeCity
                 select order.pricePaid).Sum();

            return Ok(result);
        }
    }
}
