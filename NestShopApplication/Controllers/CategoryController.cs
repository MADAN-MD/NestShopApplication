using Microsoft.AspNetCore.Mvc;
using NestShopApplication.Models;
using NestShopApplication.Repository.IRepository;

namespace NestShopApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList = _unitOfWork.Category.GetAll().ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            try
            {
                if (model.Name == model.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Name and order value should be different.");
                }
                if (!ModelState.IsValid)
                {
                    return View();
                }

                _unitOfWork.Category.Add(model);
                _unitOfWork.Save();

                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var entity = _unitOfWork.Category.Get(x => x.Id == id);

                if (entity == null)
                {
                    return NotFound();
                }
                return View(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var entity = _unitOfWork.Category.Get(x => x.Id == model.Id);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.DisplayOrder = model.DisplayOrder;

                _unitOfWork.Category.Update(entity);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var entity = _unitOfWork.Category.Get(x => x.Id == id);

                if (entity == null)
                {
                    return NotFound();
                }

                _unitOfWork.Category.Remove(entity);
                _unitOfWork.Save();
                TempData["success"] = "Category removed successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
