using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySelf.Controllers
{
    public class FilterController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        // GET: Filter
        public ActionResult Index(string Employee, string Customer, string OrderDetail)
        {
            var EmployeesFilter = db.Employees.Select(item=>item.FirstName).ToList();
            EmployeesFilter.Insert(0, "");
            ViewBag.EmployeesFilter = EmployeesFilter;

            var CustomersFilter = db.Customers.Select(item => item.CompanyName).ToList();
            CustomersFilter.Insert(0, "");
            ViewBag.CustomersFilter = CustomersFilter;

            var OrderDetailsFilter = db.Order_Details.Select(i => i.UnitPrice.ToString()).ToList();
            OrderDetailsFilter.Insert(0, "");
            ViewBag.OrderDetailsFilter = OrderDetailsFilter;

            int? EmployeeId = null;
            string CustomerId = null;
            List<int> orderDetails = new List<int>();

            if (!String.IsNullOrEmpty(Employee))
                EmployeeId = db.Employees.Where(item=>item.FirstName == Employee).First().EmployeeID;
            if (!String.IsNullOrEmpty(Customer))
                CustomerId = db.Customers.Where(item => item.CompanyName == Customer).First().CustomerID;
            if (!String.IsNullOrEmpty(OrderDetail))
                orderDetails = db.Order_Details.Where(item => item.UnitPrice.ToString() == OrderDetail).Select(i=>i.OrderID).ToList();



            var Orders = db.Orders.
                Where(item => item.EmployeeID == (EmployeeId ?? item.EmployeeID)
                && item.CustomerID == (CustomerId ?? item.CustomerID) && orderDetails.Contains(item.OrderID));

            ViewBag.Orders = Orders.ToList();



            return View(Orders.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}