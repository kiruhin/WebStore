using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник"
            },
            new EmployeeViewModel
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                Position = "Программист"
            }
        };

        // /home/index
        public IActionResult Index()
        {
            return View();
        }

        // /home/Employees
        public IActionResult Employees()
        {
            return View(_employees);
        }

        // /home/EmployeeDetails/1
        public IActionResult EmployeeDetails(int id)
        {
            var employeeViewModel = _employees.FirstOrDefault(x => x.Id == id);

            //Если такого не существует
            if (employeeViewModel == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(employeeViewModel);
        }
    }
}
