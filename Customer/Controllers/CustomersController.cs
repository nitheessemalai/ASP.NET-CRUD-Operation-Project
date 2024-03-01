using CustomerDataAccessLayer.Models;
using CustomerDataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    public class CustomersController : Controller
    {
        // GET: CustomerController
        private readonly ICustomerRepository _add;
        private readonly string _connectionstring;
        public CustomersController(ICustomerRepository add, IConfiguration configuration)
        {
            _add = add;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: StudentController
        public ActionResult List()
        {
            var result = _add.GetAllCustomerDetails();
            return View("List", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(long CustomerID)
        {
            try
            {
                var result = _add.GetbyCustomerID(CustomerID);

                return View("Details", result);

            }
            catch
            {
                return View("Error");

            }

        }

        // GET: StudentController/Create
        public ActionResult Create(long? CustomerID)
        {
            if (CustomerID.HasValue)
            {
                var result = _add.GetbyCustomerID(CustomerID.Value);
                return View("Create", result);
            }
            else
            {
                var model = new CustomerDetail();
                return View("Create", model);
            }

        }

        // POST: StudentController/Create
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDetail value)
        {
            try
            {

                if (value.CustomerID == 0)
                {
                    _add.Insert(value);
                    return RedirectToAction(nameof(List));


                }
                else
                {
                    _add.Update(value.CustomerID, value);
                    return RedirectToAction(nameof(List));
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(long CustomerID)
        {
            var result = _add.GetbyCustomerID(CustomerID);
            return View("Edit", result);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long CustomerID, CustomerDetail data)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _add.Update(CustomerID, data);

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Edit", data);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete( long CustomerID)
        {
            var result = _add.GetbyCustomerID(CustomerID);
            return View("Delete", result);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebyid(long CustomerID)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _add.Deletebyid(CustomerID);

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Delete");
                }
            }
            catch
            {
                return View();
            }
        }
    }
    
}
