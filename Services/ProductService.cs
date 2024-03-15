using MVCApp.Models;

namespace MVCApp.Services
{
    public class ProductService: List<Product>
    {
        public ProductService() {
            this.Add(new Product { Id = 1, Name = "Iphone 15", Price = 2000 }
                );
            this.Add(new Product { Id = 2, Name = "Samsung S24 Ultra", Price = 2500 });
            this.Add(new Product { Id = 3, Name = "Xiaomi", Price = 1500 });
        }
    }
}
