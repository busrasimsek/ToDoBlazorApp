using AutoMapper;
using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;

namespace ToDoBlazorApp.AutoMapper.CategoryMapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
        }
    }
}
