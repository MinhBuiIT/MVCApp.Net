using Microsoft.AspNetCore.Mvc;
using MVCApp.Services;

namespace MVCApp.Areas.ProductManage.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name);
            return View(products);
        }
    }
}
