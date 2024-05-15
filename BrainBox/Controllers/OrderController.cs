using AspNetCoreHero.ToastNotification.Abstractions;
using BrainBox.Models;
using BrainBox.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainBox.Controllers
{
    public class OrderController : Controller
    {

        IToyLayer itoylayer;
        IOrderLayer iorderlayer;
        // Notifications ##
        public INotyfService _notifyService { get; }
        public static List<Order> Cart = new List<Order>();
        public OrderController(IToyLayer _itoylayer, IOrderLayer _iorderlayer, INotyfService notifyService)
        {
            itoylayer = _itoylayer;
            iorderlayer = _iorderlayer;
            _notifyService = notifyService;
            
        }
       
        [Authorize]
        public IActionResult Buy(int id,string name)
        {
            var toy = itoylayer.All().FirstOrDefault(i => i.Id == id);
            Order order = new Order();
            order.TotalPrice = toy.Price;
            order.OrderName = "1 of " + toy.Name;
            order.ClientName = name;
            iorderlayer.Add(order);
            TempData["OrderAdded"] = "sccess";
            _notifyService.Success("Order Added To your Shopping Cart");
            Cart.Add(order);
            return RedirectToAction("ViewInCards", "Toy");
        }
       
        public IActionResult All()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
            var userName = User.Identity.Name; // Get the username
            ViewBag.IsAdmin = role == "Admin";
            ViewBag.IsClient = role == "Client";
            ViewBag.UserName = userName;

            ViewBag.Cart = Cart.ToList();
            return View(iorderlayer.All().ToList());
        }

        public IActionResult Remove(int id)
        {
            var item = iorderlayer.All().FirstOrDefault(e => e.Id == id);
            if (item == null)
            {
                throw new Exception("No toy Orders this id");
            }
            ViewData["OrderDeleted"] = "error";
            iorderlayer.Remove(item);
            _notifyService.Warning("Order deleted ");
            ViewBag.itemDeleted = item.TotalPrice;
            Cart.Remove(item);
            iorderlayer.Remove(item);
            return RedirectToAction("All");
        }

    }
}
