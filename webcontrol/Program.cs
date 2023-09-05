using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using webcontrol.Models;
using webcontrol.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient(typeof(ILogger<>), typeof(ILogger<>));
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // /Views/Controller/Action.cshtml

    // {0} -> tên action
    // {1} -> tên controller
    // {0} -> tên area

    options.ViewLocationFormats.Add("/Views/{1}/{0}"+ RazorViewEngine.ViewExtension);

});
//builder.Services.AddSingleton<ProductService>();
//builder.Services.AddSingleton<ProductService, ProductService>();
//builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    //sayhi
    endpoints.MapGet("/sayhi", async (context) =>
    {
        await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
    });
    endpoints.MapControllerRoute(
        name: "default",
        pattern:"Home",
        defaults: new
        {
            controller = "Home",
            action = "Index"
        });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations


app.MapControllerRoute(
    name: "MyAreaProducts",
    pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
