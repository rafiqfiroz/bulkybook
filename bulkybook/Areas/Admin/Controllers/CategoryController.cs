using Bulkybook.Models.Models;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace bulkybook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategories = _unitOfWork.Category.GetAll();
            return View(objCategories);
        }
        //Get
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot be same as Name");
            }
            //if (category.Displayorder==category.Displayorder)
            //{
            //    ModelState.AddModelError("Display Order","Display Order should not be the same");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Save successfully";

                return RedirectToAction("Index");
            }
            return View(category);

        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryobj = _db.Categories.Find(id);
            var categoryobj = _unitOfWork.Category.GetFirstorDefault(u => u.Name == "Id");
            if (categoryobj == null)
            {
                return NotFound();
            }
            return View(categoryobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "The display order cannot be same as Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Update successfully";
                return RedirectToAction("Index");
            }
            return View(category);

        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryobj = _unitOfWork.Category.GetFirstorDefault(u => u.Id == id);
            if (categoryobj == null)
            {
                return NotFound();
            }
            return View(categoryobj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
