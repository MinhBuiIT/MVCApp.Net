using Microsoft.AspNetCore.Mvc.Razor;
using MVCApp.Services;

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

app.UseAuthentication();
app.UseAuthorization();

//truy cập tới các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//truy cập tới các razor page
app.MapRazorPages();
app.Run();
