using Microsoft.AspNetCore.Mvc;
using webcontrol.Services;

namespace webcontrol.Controllers
{
    public class FirstController : Controller
    {
        public readonly ILogger<FirstController> _logger;
        //public readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger) 
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Readme()
        {
            var content = @"ha hung trang";
            return Content(content, "text/html");
        }
        public IActionResult HiView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "Khách";
            }
            return View("XinChao", username);
        }
        //public IActionResult Product(int? id) {
        //    var product = _productService.Where(p => p.Id == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        TempData["StatusMessage"] = "Không có dữ liệu";
        //        return Redirect(Url.Action("Index","Home"));
        //    }
        //    //Model
        //    //return View(product);

        //    //ViewData
        //    this.ViewData["product"] = product;
        //    return View("Product");
        //}
    }
}
