using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;

namespace ToDoBlazorApp.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProductsAsync();
        Task<bool> AddProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(int id, ProductModel product);
        Task<bool> DeleteProductAsync(int id);
    }
}
