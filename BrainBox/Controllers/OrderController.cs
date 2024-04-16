using BrainBox.Models;
using BrainBox.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainBox.Controllers
{
    public class OrderController : Controller
    {

        IToyLayer itoylayer;
        IOrderLayer iorderlayer;
        public OrderController(IToyLayer _itoylayer, IOrderLayer _iorderlayer)
        {
            itoylayer = _itoylayer;
            iorderlayer = _iorderlayer;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Toys = itoylayer.All().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                iorderlayer.Add(order);
                return RedirectToAction("All");
            }
            ViewBag.Toys = itoylayer.All().ToList();
            return View(order);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Toys = itoylayer.All().ToList();
            var item =  iorderlayer.All().FirstOrDefault(e => e.Id == id);
            return View( item);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            var item = iorderlayer.All().FirstOrDefault(e => e.Id == order.Id);
            if (item == null)
            {
                throw new Exception("No toy match this id");
            }
            if (ModelState.IsValid)
            {
                iorderlayer.Edit(item);
                return RedirectToAction("All");
            }
            ViewBag.Toys = itoylayer.All().ToList();
            return View(order);
        }

        public IActionResult All()
        {
            ViewBag.Toys = itoylayer.All().ToList();
            return View(iorderlayer.All().ToList());
        }

        public IActionResult Remove(int id)
        {
            var item = iorderlayer.All().FirstOrDefault(e => e.Id == id);
            if (item == null)
            {
                throw new Exception("No toy Orders this id");
            }
            iorderlayer.Remove(item);
            return RedirectToAction("All");
        }

    }
}
