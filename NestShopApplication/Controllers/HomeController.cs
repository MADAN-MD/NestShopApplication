using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id, includeProperties: "Category");

            return View(product);
        }

        [HttpGet]
        public IActionResult CreateBanner(int? id)
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category
                .GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                });

            //ViewBag.CategoryList = categoryList;
            ProductViewModel viewModel = new ProductViewModel()
            {
                CategoryList = categoryList,
                Product = new Product()
            };

            if (id == null || id == 0)
            {
                return View(viewModel);
            }
            else
            {
                //update
                viewModel.Product = _unitOfWork.Product.Get(x => x.Id == id);
                return View(viewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
