using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using MVCApp.MyExtension;
using MVCApp.Services;
using System.Net;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();//đky vào ứng dụng các dịch vụ mvc
builder.Services.AddRazorPages();
//Config để action tìm View 
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    //Mặc định /Views/Controller/Action.cshtml
    //{0}: Action
    //{1}: Controller
    //{2}: Area
    //RazorViewEngine.ViewExtension ~ .cshtml
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddSingleton<ProductService, ProductService>();
builder.Services.AddSingleton<PlanetService, PlanetService>();
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

app.AddStatusCodePage();//trong myextension folder
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//truy cập tới các controller
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//truy cập tới các razor page
app.MapRazorPages();

//app.MapControllers();
//app.MapControllerRoute();
//app.MapAreaControllerRoute();

//truy cap secondPage ~ SecondController -> ShowProduct -> id = 2
//app.MapControllerRoute(
//    name: "second-name",
//    pattern: "secondPage",
//    new
//    {
//        controller = "Second",
//        action = "ShowProduct",
//        id = 2
//    }
//    );

// /cbajchbhba/1 -> /Second/ShowProduct/{id}
app.MapControllerRoute(
    name: "anyProduct",
    pattern: "{url}/{id?}",
    new
    {
        controller = "Second",
        action = "ShowProduct"
    },
    //Microsoft.AspNetCore.Routing.Constraints Namespace
    constraints: new
    {
        url = new RegexRouteConstraint("^(hienthisp)|(viewproduct)$"),
        id = new IntRouteConstraint()
    }
    );


app.MapAreaControllerRoute(
    name: "areas",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName: "ProductManage"
    );

//chỉ dùng cho controller không có areas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
//app.MapControllerRoute(
//        name: "second-name",
//        pattern: "hienthisp/{id?}",
//        new
//        {
//            controller = "Second",
//            action = "ShowProduct"
//        }
//    );

app.Run();
