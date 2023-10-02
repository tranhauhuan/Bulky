using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
           if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(); 
        }

        public IActionResult Edit(int? Id)
        {
           
            if (Id == null || Id ==0)
            {
                return NotFound();
            }
            Category category = _db.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
           if( ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }

        public IActionResult Delete(int Id)
        {

            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            Category category = _db.Categories.Find(Id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int Id)
        {
            Category category = _db.Categories.Find(Id);
            if (category ==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
