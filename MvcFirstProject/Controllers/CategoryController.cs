using Microsoft.AspNetCore.Mvc;
using MvcFirstProject.Data;
using MvcFirstProject.Models;

namespace MvcFirstProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        } 
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.categories;
            return View(CategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayProperty.ToString()) {
                ModelState.AddModelError("CustomCategoryError", "Name and DisplayProperty can't exactly same.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["succes"] = "Category create succesfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }

            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null) {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayProperty.ToString())
            {
                ModelState.AddModelError("CustomCategoryError", "Name and DisplayProperty can't exactly same.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["succes"] = "Category update succesfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.categories.Find(id);
            
            if(obj != null) {
                _db.categories.Remove(obj);
                _db.SaveChanges();
                TempData["succes"] = "Category delete succesfuly";
            }
            return RedirectToAction("Index"); 
        }
    }
}
