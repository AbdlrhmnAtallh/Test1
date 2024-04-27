using BrainBox.Models;
using Microsoft.AspNetCore.Mvc;
using BrainBox.Services;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BrainBox.Controllers
{
    public class ToyController : Controller
    {
        IToyLayer itoylayer;
        IOrderLayer iorderlayer;
        // Notifications ##
        public INotyfService _notifyService { get; }
        public ToyController(IToyLayer _itoylayer,IOrderLayer _iorderlayer, INotyfService notifyService)
        {
            itoylayer = _itoylayer;
            iorderlayer = _iorderlayer;
            _notifyService = notifyService;
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
                _notifyService.Information("Toy Added ");
                itoylayer.Add(toy);
                
                return RedirectToAction("All");
            }
            _notifyService.Error("Can't Add this toy please enter a valid informations");
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
                ViewData["ToyUpdated"] = "info";
                return RedirectToAction("All");
            }
            ViewBag.Orders = iorderlayer.All().ToList();
            return View(toy);
        }

        public IActionResult All()
        {
            ViewBag.Orders = iorderlayer.All().ToList();
            TempData["OrderAdded"] = "sccess";
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
            _notifyService.Warning("Toy deleted");
            return RedirectToAction("All");
        }

        public IActionResult ViewInCards()
        {
            var userName = User.Identity.Name;
            ViewBag.UserName = userName;
            ViewBag.Cards = true;
            
            return View("All", itoylayer.All().ToList());
        }

    }
}
