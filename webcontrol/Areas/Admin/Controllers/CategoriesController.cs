using Microsoft.AspNetCore.Mvc;
using webcontrol.Areas.Admin.Models;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listFromDB = _context.Categories.ToList().Select(
                x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,    
                }).ToList();
            return View(listFromDB);
        }

        [HttpGet]
        public IActionResult Create()
        {
        CategoryViewModel category = new CategoryViewModel();
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel vm)
        {
            CategoryModel model = new CategoryModel();
            model.Title = vm.Title;
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _context.Categories.Where(x => x.Id == id)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                }).FirstOrDefault();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var categoryFromDB = _context.Categories.FirstOrDefault(x=>x.Id == vm.Id);
                if (categoryFromDB != null)
                {
                     categoryFromDB.Title = vm.Title;
                    _context.Categories.Update(categoryFromDB);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if(category != null) {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
