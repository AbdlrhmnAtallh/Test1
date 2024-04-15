using BrainBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrainBox.Controllers
{
    public class OrderController : Controller
    {
        public static List<Order> Orders { get; set; }
        public OrderController() 
        {
            List<int> ordersids = new List<int>();
            ordersids.Add(001);
            Orders.Add(new Order { Id = 001, OrderNo = 1, TotalPrice = 0, ToysIds = ordersids });
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Toys = ToyController.Toys.ToList();
            ViewBag.Orders = Orders.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {

                Orders.Add(order);
                return RedirectToAction("All");
            }
            ViewBag.Toys = ToyController.Toys.ToList();
            ViewBag.Orders = Orders.ToList();
            return View(order);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Toys = ToyController.Toys.ToList();
            ViewBag.Orders = Orders.ToList();
            var item = Orders.FirstOrDefault(e => e.Id == id);
            return View("Add", item);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            var item = Orders.FirstOrDefault(e => e.Id == order.Id);
            if (item == null)
            {
                throw new Exception("No toy match this id");
            }
            if (ModelState.IsValid)
            {
                item.OrderNo = order.OrderNo;
                item.TotalPrice = order.TotalPrice;
                item.Id = order.Id;
                return RedirectToAction("All");
            }
            ViewBag.Toys = ToyController.Toys.ToList();
            ViewBag.Orders = Orders.ToList();
            return View("Add", order);
        }

        public IActionResult Remove(int id)
        {
            var item = Orders.FirstOrDefault(e => e.Id == id);
            if (item == null)
            {
                throw new Exception("No toy Orders this id");
            }
            Orders.Remove(item);
            return RedirectToAction("All");
        }

    }
}
