using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
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
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
    }
}
