using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    public class LoginLogoutVc : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
