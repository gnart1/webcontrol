using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using webcontrol.Security.Requirements;
using webcontrol.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using webcontrol.Models;

namespace webcontrol
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    string connectString = Configuration.GetConnectionString("AppMvcConnectionString");
            //    options.UseSqlServer(connectString, b => b.MigrationsAssembly("webcontrol"));
            //});
            //services.AddOptions();
            //var mailsetting = Configuration.GetSection("MailSettings");
            //services.Configure<MailSettings>(mailsetting);
            //services.AddSingleton<IEmailSender, SendMailService>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppMvcConnectionString")));

            services.AddControllersWithViews();

            services.AddRazorPages(options =>
            {

            });

            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    string connectString = Configuration.GetConnectionString("MyBlogContext");
            //    options.UseSqlServer(connectString);
            //});


            // Dang ky Identity
            /*
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            */
            // services.AddDefaultIdentity<webcontrolUser>()
            //         .AddEntityFrameworkStores<MyBlogContext>()
            //         .AddDefaultTokenProviders();


            // Truy cập IdentityOptions
            services.Configure<IdentityOptions>(options =>
            {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 3; // Thất bại 3 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất


                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
                options.SignIn.RequireConfirmedAccount = true;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login/";
                options.LogoutPath = "/logout/";
                options.AccessDeniedPath = "/khongduoctruycap.html";
            });
            /*
            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        var gconfig = Configuration.GetSection("Authentication:Google");
                        options.ClientId = gconfig["ClientId"];
                        options.ClientSecret = gconfig["ClientSecret"];
                        // https://localhost:5001/signin-google
                        options.CallbackPath = "/dang-nhap-tu-google";
                    })
                    .AddFacebook(options =>
                    {
                        var fconfig = Configuration.GetSection("Authentication:Facebook");
                        options.webcontrolId = fconfig["webcontrolId"];
                        options.webcontrolSecret = fconfig["webcontrolSecret"];
                        options.CallbackPath = "/dang-nhap-tu-facebook";
                    })
                    // .AddTwitter()
                    // .AddMicrosoftAccount()
                    ;
            */
            //services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();

            services.AddAuthorization(options =>
            {

                options.AddPolicy("AllowEditRole", policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.RequireClaim("canedit", "user");
                });

                //options.AddPolicy("InGenZ", policyBuilder =>
                //{
                //    policyBuilder.RequireAuthenticatedUser();
                //    // policyBuilder.RequireClaim("canedit", "user");
                //    policyBuilder.Requirements.Add(new GenZRequirement()); // GenZRequirement

                //    // new GenZRequirement() -> Authorization handler

                //});

                options.AddPolicy("ShowAdminMenu", pb =>
                {
                    pb.RequireRole("Admin");
                });

                //options.AddPolicy("CanUpdateArticle", builder =>
                //{
                //    builder.Requirements.Add(new ArticleUpdateRequirement());
                //});

            });

            //services.AddTransient<IAuthorizationHandler, AppAuthorizationHandler>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder webcontrol, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                webcontrol.UseDeveloperExceptionPage();
            }
            else
            {
                webcontrol.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                webcontrol.UseHsts();
            }

            webcontrol.UseHttpsRedirection();
            webcontrol.UseStaticFiles();

            webcontrol.UseRouting();

            webcontrol.UseAuthentication();
            webcontrol.UseAuthorization();

            webcontrol.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });



        }
    }
}
