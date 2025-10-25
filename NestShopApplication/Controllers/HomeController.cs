using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using NestShopApplication.Models;
using NestShopApplication.Repository.IRepository;
using NestShopApplication.ViewModels;
using System.Diagnostics;

namespace NestShopApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            var banner = _unitOfWork.Banner.GetAll().OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            ViewBag.Banner_image = banner != null ? banner.ImageUrl : null;

            var products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id, includeProperties: "Category");

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin,seller")]
        public IActionResult Create(Banner model, IFormFile? file)
        {
            try
            {
                var createdDate = DateTime.Now;
                model.CreatedDate = createdDate;
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\banners");

                    if (!string.IsNullOrEmpty(model.ImageUrl))
                    {
                        //delete old image
                        var oldImagePath = Path.Combine(wwwRootPath, model.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    model.ImageUrl = @"\images\banners\" + fileName;
                }

                if (model.Id == 0)
                {
                    _unitOfWork.Banner.Add(model);

                }
                else
                {
                    _unitOfWork.Banner.Update(model);
                }
                _unitOfWork.Save();

                TempData["success"] = "Banner successfully Created.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
