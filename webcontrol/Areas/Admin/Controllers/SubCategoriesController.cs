using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using webcontrol.Areas.Admin.Models;
using webcontrol.Migrations;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public SubCategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var subCategory = _context.SubCategories.Include(x=> x.Category).ToList();
            return View(subCategory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SubCategoryViewModel vm = new SubCategoryViewModel();
            ViewBag.category = new SelectList(_context.Categories, "Id", "Title");
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(SubCategoryViewModel vm)
        {
            SubCategoryModel model = new SubCategoryModel();
            if (ModelState.IsValid)
            {
                model.Title = vm.Title;
                model.CategoryId = vm.CategoryId;
                _context.SubCategories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(vm);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SubCategoryModel model = new SubCategoryModel();
            var viewModel = _context.SubCategories.Where(x=>x.Id == id).
                Select(x=> new SubCategoryViewModel() 
                {
                   Id = x.Id,
                   Title =  x.Title, 
                   CategoryId = x.CategoryId }).FirstOrDefault();
            if (viewModel != null)
            {
                model.Id = viewModel.Id;
                model.Title = viewModel.Title;
                ViewBag.category = new SelectList(_context.Categories, "Id", "Title", viewModel.CategoryId);
            }
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(SubCategoryViewModel vm)
        {
            var subCategoryFromDB = _context.SubCategories.Where(x => x.Id == vm.Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (subCategoryFromDB != null)
                {
                    subCategoryFromDB.Title = vm.Title;
                    subCategoryFromDB.CategoryId = vm.CategoryId;
                    _context.SubCategories.Update(subCategoryFromDB);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           
            var subCategory = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (subCategory != null)
            {
                _context.Categories.Remove(subCategory);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
