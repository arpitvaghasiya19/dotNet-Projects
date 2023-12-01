using CodeFirstAjax.Data;
using CodeFirstAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAjax.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationContext context;

        public CustomerController(ApplicationContext context)
        {
            this.context = context;  hghg 
        }
        public IActionResult Index()
        {
            var result = context.Customers.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                var cs = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    Address = new Address
                    {
                        City = model.Address?.City,
                        State = model.Address?.State,
                        PinCode = model.Address?.PinCode
                    }
                };

                context.Customers.Add(cs);
                context.SaveChanges();

                TempData["error"] = "Data Saved";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Add data in Empty Field";
                return View(model);
            }

        }


        public IActionResult Delete(int id)
        {
            var cs = context.Customers.SingleOrDefault(C => C.ID == id);
            context.Customers.Remove(cs);
            context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cs = context.Customers.SingleOrDefault(C => C.ID == id);
            var result = new Customer()
            {
                FirstName = cs.FirstName,
                LastName = cs.LastName,
                Age = cs.Age,
                Email = cs.Email
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            var cs = new Customer()
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Email = model.Email
            };
            context.Customers.Update(cs);
            context.SaveChanges();
            TempData["error"] = "Record updated. ";
            return RedirectToAction("Index");
        }

        

        [HttpGet]
        public IActionResult GetAddress(int customerId)
        {
            var address = context.Addresses
                .Where(a => a.CustomerId == customerId)
                .FirstOrDefault();

            return PartialView("_AddressPartial", address);
        }

    }
}
