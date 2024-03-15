using Microsoft.AspNetCore.Mvc;
using MVCApp.Services;

namespace MVCApp.Controllers
{
    public class SecondController : Controller
    {
        private ProductService _productSevice;

        [TempData]
        public string StatusMessage {  get; set; }
        public SecondController(ProductService productSevice)
        {
            _productSevice = productSevice;
        }
        public ActionResult ShowProduct(int? id) {
            
            var product = _productSevice.Where(x => x.Id == id).FirstOrDefault();
            if(id == null || product == null)
            {
                StatusMessage = "Không tìm thấy sản phẩm";
                return LocalRedirect(Url.Action("Index", "Home"));
            }
            //return View(product);
            ViewData["product"] = product;
            return View("ShowProduct2");
        }
    }
}
