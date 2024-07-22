using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoBlazorApp.Context;
using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;
using ToDoBlazorApp.Services.Abstract;

namespace ToDoBlazorApp.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly BlazorAppDbContext _blazorAppDbContext;
        private readonly IMapper _mapper;
        public CategoryService(BlazorAppDbContext blazorAppDbContext, IMapper mapper)
        {
            _blazorAppDbContext = blazorAppDbContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var category= await _blazorAppDbContext.Categories.ToListAsync();
            return  _mapper.Map<List<CategoryModel>>(category);
        }

        public async Task<bool> AddCategoryAsync(CategoryModel categoryModel)
        {
            try
            {
                var category= _mapper.Map<Category>(categoryModel);
                await _blazorAppDbContext.Categories.AddAsync(category);
                await _blazorAppDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryModel categoryModel)
        {
            try
            {
                var existingCategory = await _blazorAppDbContext.Categories.FindAsync(id);
                if (existingCategory == null)
                {
                    return false;
                }

                _mapper.Map(categoryModel, existingCategory);

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
                    return false;
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
