using Microsoft.EntityFrameworkCore;
using ToDoBlazorApp.Context;
using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;
using ToDoBlazorApp.Services.Abstract;

namespace ToDoBlazorApp.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly BlazorAppDbContext _blazorAppDbContext;
        public ProductService(BlazorAppDbContext blazorAppDbContext)
        {
            _blazorAppDbContext = blazorAppDbContext;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            return await _blazorAppDbContext.Products.Include(p => p.Category).Select(x=> new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _blazorAppDbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        }
        public async Task<bool> AddProductAsync(ProductModel productModel)
        {
            try
            {
                var product = new Product
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    StockQuantity = productModel.StockQuantity,
                    CategoryId = productModel.CategoryId
                };
                await _blazorAppDbContext.Products.AddAsync(product);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateProductAsync(int id, ProductModel productModel)
        {
            try
            {
              
                var existingProduct = await _blazorAppDbContext.Products.FindAsync(id);
                if (existingProduct == null)
                {
                    return false;
                }
                existingProduct.Id = id;
                existingProduct.Name = productModel.Name;
                existingProduct.CategoryId = productModel.CategoryId;
                existingProduct.Category.CategoryName = productModel.CategoryName;
                existingProduct.Price = productModel.Price;
                existingProduct.StockQuantity = productModel.StockQuantity;
                existingProduct.Description = productModel.Description;

                _blazorAppDbContext.Products.Update(existingProduct);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _blazorAppDbContext.Products.FindAsync(id);
                if (product == null)
                {
                    return false;
                }

                _blazorAppDbContext.Products.Remove(product);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
