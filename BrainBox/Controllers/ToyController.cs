using BrainBox.Models;
using Microsoft.AspNetCore.Mvc;
using BrainBox.Services;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Orders = iorderlayer.All().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Toy toy, IFormFile image)
        {
            var item = itoylayer.All().FirstOrDefault(e => e.Id == toy.Id);
            if (item != null) { ModelState.AddModelError("", "This Id is exists, try another id"); }
            if (ModelState.IsValid)
            {
                // Save the image file
                if (image != null && image.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                    // Create the directory if it doesn't exist
                    var directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                    toy.ImageFileName = fileName;
                }

                itoylayer.Add(toy);
                
                return RedirectToAction("All");
            }
            ViewBag.Orders = iorderlayer.All().ToList();
            return View(toy);
        }


        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ViewBag.Orders = iorderlayer.All().ToList();
            var item = itoylayer.All().FirstOrDefault(e => e.Id == id);
            return View(item);
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public IActionResult Edit(Toy toy)
        {
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
        [Authorize(Policy = "Admin")]
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

        public IActionResult ViewInCards()
        {
            ViewBag.Cards = true;
            return View("All", itoylayer.All().ToList());
        }

    }
}
