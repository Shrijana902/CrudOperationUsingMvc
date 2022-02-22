using MvcProject.Data;
using MvcProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList=_db.Categories;
             return View(objCategoryList);
        }
       
        //Get
         public IActionResult Create()
        {
            
             return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if(ModelState.IsValid){
            
            _db.Categories.Add(obj);
            
            _db.SaveChanges();
            TempData["success"]="Category created successfully";
             return RedirectToAction("Index");
            }
            return View(obj);
        }
         //Get
         public IActionResult Edit(int? id)
        {
            if(id==null ||id==0){
                return NotFound();
            }
            var categoryFromDb=_db.Categories.Find(id);
            if(categoryFromDb==null)
            {
                return View(categoryFromDb);
            }
             return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if(ModelState.IsValid){
            
            _db.Categories.Update(obj);
            
            _db.SaveChanges();
            TempData["success"]="Category updated successfully";
             return RedirectToAction("Index");
            }
            return View(obj);
        }
           




         //Get
         public IActionResult Delete(int? id)
        {
            if(id==null ||id==0){
                return NotFound();
            }
            var categoryFromDb=_db.Categories.Find(id);
            if(categoryFromDb==null)
            {
                return View(categoryFromDb);
            }
             return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj=_db.Categories.Find(id);
            if(id==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
           
            _db.SaveChanges();
             TempData["success"]="Category deleted successfully";
            return RedirectToAction("Index");
            

        
        }
        
       
    }


}