using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class FirstController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public IActionResult Index()
        {
            return View();
        }
        public FirstController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Content()
        {
            return Content("Action Content", "text/html");
        }
        public IActionResult File()
        {
            string path = Path.Combine(_env.ContentRootPath, "Files", "img1.jpg");
            var bytes = System.IO.File.ReadAllBytes(path);//chuyển hình thành mảng bytes
            return File(bytes, "image/jpg");
        }
        public IActionResult Json()
        {
            return Json(
                new
                {
                    ProductId = 1,
                    ProductName = "Iphone 15 Pro Max"
                }
                );
        }

        //LocalRedirect: local ~ host vs Redirect có thể điều hướng trang bên ngoài
        public IActionResult Hello(string? username)
        {
            if(username == null)
            {
                username = "Khách";
            }
            return View((object)username);
        }
        public IActionResult Hi()
        {
            return View();
        }
    }
}
