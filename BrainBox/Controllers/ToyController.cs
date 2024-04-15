using BrainBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrainBox.Controllers
{
    public class ToyController : Controller
    {
        public static List<Toy> Toys { get; set; }
        public ToyController()
        {
            Toy toy = new Toy();
            toy.Id = 001;
            toy.Name = "ToyA";
            toy.Price = 10;
            toy.Discription = " This Toy Added by system you can deleteit";
            toy.InStock= true;
            toy.OrderId = new List<int>();
            toy.OrderId.Add(001);

            Toys.Add(toy);
        }

        [HttpGet]
        public IActionResult Add()
        {           
            ViewBag.Toys = Toys.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Toy toy)
        {
            if (ModelState.IsValid)
            {
               
                Toys.Add(toy);
                return RedirectToAction("All");
            }
            ViewBag.Orders = OrderController.Orders.ToList();
            ViewBag.Toys = Toys.ToList();
            return View(toy);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Orders = OrderController.Orders.ToList();
            ViewBag.Toys= Toys.ToList();
            var item = Toys.FirstOrDefault(e => e.Id == id);
            return View("Add",item);
        }
        [HttpPost]
        public IActionResult Edit(Toy toy)
        {
            var item = Toys.FirstOrDefault(e => e.Id == toy.Id);
            if(item== null)
            {
                throw new Exception("No toy match this id");
            }
            if (ModelState.IsValid)
            {
                item.Name = toy.Name;
                item.Price = toy.Price;
                item.Discription = toy.Discription;
                item.InStock = toy.InStock;
                return RedirectToAction("All");
            }
            ViewBag.Orders = OrderController.Orders.ToList();
            ViewBag.Toys = Toys.ToList();
            return View("Add",toy);
        }
        
        public IActionResult Remove(int id)
        {
            var item = Toys.FirstOrDefault(e => e.Id == id);
            if(item== null)
            {
                throw new Exception("No toy match this id");
            }
            Toys.Remove(item);
            return RedirectToAction("All");
        }

    }
}
