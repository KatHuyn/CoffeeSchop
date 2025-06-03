
using coffeeshop.Models.Services;
using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private ShoppingCartRepository shoppingCartRepository;
        public OrdersController(IOrderRepository oderRepository, ShoppingCartRepository shoppingCartRepossitory)
        {
            this.orderRepository = oderRepository;
            this.shoppingCartRepository = shoppingCartRepossitory;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}