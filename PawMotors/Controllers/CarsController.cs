using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using PawMotors.Entity;
using PawMotors.ProjeContext;

namespace PawMotors.Controllers
{
    public class CarsController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public JsonResult GetCars()
        {
            var cars = context.Cars.ToList();
            return Json(cars);
        }
        public IActionResult Index()
        {
            var values = context.Cars.ToList();
            return View(values);
        }

        [HttpGet] //sayfa yüklendiği zaman çalış
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCar([FromBody] Cars newCar)
        {
            if (ModelState.IsValid)
            {
                context.Cars.Add(newCar);
                context.SaveChanges();
                return Json(new { success = true, message = "Car added successfully!" });
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

        public IActionResult DeleteCar(int id)
        {
            var value = context.Cars.Where(x => x.Id == id).FirstOrDefault();
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            var value = context.Cars.Where(x => x.Id == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCar(Cars car)
        {
            var value = context.Cars.Where(x => x.Id == car.Id).FirstOrDefault();
            value.Brand = car.Brand;
            value.Model = car.Model;
            value.Year = car.Year;
            value.Color = car.Color;
            value.Price = car.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}