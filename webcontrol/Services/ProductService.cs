using webcontrol.Models;

namespace webcontrol.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService() 
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {Id = 1, Name = "IphoneX", Description = "128GB", Price = 500},
                new ProductModel() {Id = 2, Name = "Iphone 11", Description = "256GB", Price = 1000},
                new ProductModel() {Id = 3, Name = "Iphone 12", Description = "256GB", Price = 1500},
                new ProductModel() {Id = 4, Name = "Iphone 13", Description = "256GB", Price = 2000},
                new ProductModel() {Id = 5, Name = "Iphone 14", Description = "128GB", Price = 2500},
            });
        }
    }
}
