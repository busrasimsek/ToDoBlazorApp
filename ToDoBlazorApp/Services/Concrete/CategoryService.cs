using Microsoft.EntityFrameworkCore;
using ToDoBlazorApp.Context;
using ToDoBlazorApp.Data;
using ToDoBlazorApp.Services.Abstract;

namespace ToDoBlazorApp.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly BlazorAppDbContext _blazorAppDbContext;
        public CategoryService(BlazorAppDbContext blazorAppDbContext)
        {
            _blazorAppDbContext = blazorAppDbContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _blazorAppDbContext.Categories.ToListAsync();
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                await _blazorAppDbContext.Categories.AddAsync(category);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            try
            {
                var existingCategory = await _blazorAppDbContext.Categories.FindAsync(id);
                if (existingCategory == null)
                {
                    return false;
                }

                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;

                _blazorAppDbContext.Categories.Update(existingCategory);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _blazorAppDbContext.Categories.FindAsync(id);
                if (category == null)
                {
                    return false; // Kategori bulunamadı
                }

                _blazorAppDbContext.Categories.Remove(category);
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
