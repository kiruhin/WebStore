using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrdersService _ordersService;

        public CartController(ICartService cartService, IOrdersService ordersService)
        {
            _cartService = cartService;
            _ordersService = ordersService;
        }

        public IActionResult Details()
        {
            var model = new OrderDetailsViewModel()
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = new OrderViewModel()
            };

            return View(model);
        }

        public IActionResult DecrementFromCart(int id)
        {
            _cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }

        public IActionResult RemoveAll()
        {
            _cartService.RemoveAll();
            return RedirectToAction("Details");
        }

        public IActionResult AddToCart(int id, string returnUrl)
        {
            _cartService.AddToCart(id);
            return Redirect(returnUrl);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderResult = _ordersService.CreateOrder(model, _cartService.TransformCart(), User.Identity.Name);

                _cartService.RemoveAll();

                return RedirectToAction("OrderConfirmed", new { id = orderResult.Id });
            }

            var detailsModel = new OrderDetailsViewModel
            {
                CartViewModel = _cartService.TransformCart(),
                OrderViewModel = model
            };
            return View("Details", detailsModel);

        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}
