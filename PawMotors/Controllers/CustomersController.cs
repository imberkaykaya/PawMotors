using Microsoft.AspNetCore.Mvc;
using PawMotors.Entity;
using PawMotors.ProjeContext;

namespace PawMotors.Controllers
{
    public class CustomersController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customers customer)
        {
            context.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            context.Remove(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customers customer)
        {
            var value = context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            value.FirstName = customer.FirstName;
            value.LastName = customer.LastName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
