using BrainBox.Models;
using Microsoft.AspNetCore.Mvc;
using BrainBox.Services;
namespace BrainBox.Controllers
{
    public class ToyController : Controller
    {
        IToyLayer itoylayer;
        IOrderLayer iorderlayer;
        public ToyController(IToyLayer _itoylayer,IOrderLayer _iorderlayer)
        {
            itoylayer = _itoylayer;
            iorderlayer = _iorderlayer;
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Orders = iorderlayer.All().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Toy toy)
        {
            var item = itoylayer.All().FirstOrDefault(e => e.Id == toy.Id);
            if (item != null) { ModelState.AddModelError("", "This Id is exists, try another id"); }
            if (ModelState.IsValid)
            {
                itoylayer.Add(toy);
                return RedirectToAction("All");
            }
            ViewBag.Orders = iorderlayer.All().ToList();
            return View(toy);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Orders = iorderlayer.All().ToList();
            var item = itoylayer.All().FirstOrDefault(e => e.Id == id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Toy toy)
        {
            var item = itoylayer.All().FirstOrDefault(e => e.Id == toy.Id);
            if (item != null) { ModelState.AddModelError("", "This Id is exists, try another id"); }
            if (ModelState.IsValid)
            {
                itoylayer.Edit(toy);
                return RedirectToAction("All");
            }
            ViewBag.Orders = iorderlayer.All().ToList();
            return View(toy);
        }

        public IActionResult All()
        {
            ViewBag.Orders = iorderlayer.All().ToList();
            return View(itoylayer.All().ToList());
        }
        
        public IActionResult Remove(int id)
        {
            var item = itoylayer.All().FirstOrDefault(e => e.Id == id);
            if(item== null)
            {
                throw new Exception("No toy match this id");
            }
            itoylayer.remove(item);
            return RedirectToAction("All");
        }

    }
}
