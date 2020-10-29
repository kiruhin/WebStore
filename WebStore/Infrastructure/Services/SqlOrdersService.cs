using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public class SqlOrdersService : IOrdersService
    {
        private readonly WebStoreContext _context;
        private readonly UserManager<User> _userManager;

        public SqlOrdersService(WebStoreContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            return _context
                .Orders
                .Include(x => x.OrderItems)
                .Include(x => x.User)
                .Where(x => x.User.UserName == userName);
        }

        public Order GetOrderById(int id)
        {
            return _context
                .Orders
                .Include("OrderItems")
                .Include("User")
                .FirstOrDefault(x => x.Id == id);
        }

        public Order CreateOrder(OrderViewModel orderModel, CartViewModel transformCart, string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            using (var transaction = _context.Database.BeginTransaction())
            {
                var order = new Order()
                {
                    Address = orderModel.Address,
                    Name = orderModel.Name,
                    Date = DateTime.Now,
                    Phone = orderModel.Phone,
                    User = user
                };

                _context.Orders.Add(order);

                foreach (var item in transformCart.Items)
                {
                    var productVm = item.Key;
                    var product = _context.Products.FirstOrDefault(p => p.Id.Equals(productVm.Id));
                    
                    if (product == null)
                        throw new InvalidOperationException("Продукт не найден в базе");

                    var orderItem = new OrderItem()
                    {
                        Price = product.Price,
                        Quantity = item.Value,

                        Order = order,
                        Product = product
                    };

                    _context.OrderItems.Add(orderItem);
                }

                _context.SaveChanges();
                transaction.Commit();

                return order;
            }
        }
    }
}
