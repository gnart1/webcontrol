using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace webcontrol.Models
{
    public class DbInitializer : IDbInitializer
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly AppDbContext _context;
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0) 
                {
                    _context.Database.Migrate();
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (_context.Roles.Any(x => x.Name == "Admin"))
                return;
            _roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

            var user = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Admin",
                Address = "Ha Noi",
                Phone = "0963825921"
            };
            _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, "Admin");
        }

        public DbInitializer(RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager, AppDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
    }
}
