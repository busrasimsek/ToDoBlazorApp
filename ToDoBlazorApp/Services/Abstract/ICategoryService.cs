using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;

namespace ToDoBlazorApp.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<bool> AddCategoryAsync(CategoryModel category);
        Task<bool> UpdateCategoryAsync(int id, CategoryModel category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
