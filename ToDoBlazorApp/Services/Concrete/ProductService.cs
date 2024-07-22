using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductService(BlazorAppDbContext blazorAppDbContext, IMapper mapper)
        {
            _blazorAppDbContext = blazorAppDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var products = await _blazorAppDbContext.Products.Include(p => p.Category).ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<bool> AddProductAsync(ProductModel productModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productModel);
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

                _mapper.Map(productModel, existingProduct);
                //existingProduct.Id = id;
                //existingProduct.Name = productModel.Name;
                //existingProduct.CategoryId = productModel.CategoryId;
                //existingProduct.Category.CategoryName = productModel.CategoryName;
                //existingProduct.Price = productModel.Price ?? 0;
                //existingProduct.StockQuantity = productModel.StockQuantity ?? 0;
                //existingProduct.Description = productModel.Description;

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
