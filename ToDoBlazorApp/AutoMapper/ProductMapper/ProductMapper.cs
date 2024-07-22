using AutoMapper;
using ToDoBlazorApp.Data;
using ToDoBlazorApp.Models;

namespace ToDoBlazorApp.AutoMapper.ProductMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest=> dest.CategoryName, opt=> opt.MapFrom(src=> src.Category.CategoryName));
            CreateMap<ProductModel, Product>();
        }
    }
}
