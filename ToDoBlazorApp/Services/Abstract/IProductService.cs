using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;

namespace ToDoBlazorApp.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
