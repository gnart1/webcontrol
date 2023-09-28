using Microsoft.AspNetCore.Mvc;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Controllers
{
    public class CouponsController : Controller
    {
        private readonly AppDbContext _context;

        public CouponsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var coupon = _context.Coupons.ToList();
            return View(coupon);
        }
    }
}
