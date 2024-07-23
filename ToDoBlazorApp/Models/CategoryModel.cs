using System.ComponentModel.DataAnnotations;

namespace ToDoBlazorApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedUser { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
