using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using webcontrol.Areas.Admin.Models;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;

        public ItemsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _context.Items.Include(x=>x.Category).Include(y=>y.SubCategory)
                .Select(model => new ItemViewModel()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId,
                })
                .ToList();
            return View(items);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ItemViewModel vm = new ItemViewModel();
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Title");
            return View();
        }
        [HttpGet]
        public IActionResult GetSubCategory(int? categoryId)
        {
            //var subCategory = _context.SubCategories.Where(x=>x.CategoryId == categoryId).FirstOrDefault();
            var subCategoryId = _context.SubCategories
           .Where(x => x.CategoryId == categoryId)
           .Select(x => x.Id)
           .FirstOrDefault();
            return Json(new { SubCategoryId = subCategoryId });

        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemViewModel vm)
        {
            ItemModel model = new ItemModel();
            if (ModelState.IsValid)
            {
                if(vm.ImageUrl != null && vm.ImageUrl.Length > 0) 
                {
                    var uploadDir = @"Images/Items";
                    var filename = Guid.NewGuid().ToString() + "-" + vm.ImageUrl.FileName;
                    var path = Path.Combine(_webHostEnvironment.WebRootPath,uploadDir, filename);
                    await vm.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    model.Image = "/" + uploadDir + "/" + filename; 
                }
                model.Price = vm.Price;
                model.Description = vm.Description;
                model.Title = vm.Title;
                model.CategoryId = vm.CategoryId;
                model.SubCategoryId = vm.SubCategoryId;
                _context.Items.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.Items.Where(x=> x.Id== id).FirstOrDefault();
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Title", item.CategoryId);
            ViewBag.SubCategory = new SelectList(_context.Categories, "Id", "Title", item.SubCategoryId);
            return View();
        }
    }
}
