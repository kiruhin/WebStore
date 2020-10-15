using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure;

namespace WebStore.Controllers
{
    [SimpleActionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return new FileContentResult();
            //return new NotFoundResult();
            //return new JsonResult("");
            //return PartialView("_Partial/_LeftSideBar");
            //return RedirectToAction("Blog", "Home");
            //return new RedirectResult("https://google.com");
            //return StatusCode(500);


            //return new EmptyResult();
            //return Content("Hello from controller");

            //throw new Exception("Упс. Что-то пошло не так...");

            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

    }
}
