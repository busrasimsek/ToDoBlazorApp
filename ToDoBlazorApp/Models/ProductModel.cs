using System.ComponentModel.DataAnnotations;

namespace ToDoBlazorApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stock Quantity is required.")]
        [Range(0, 10000, ErrorMessage = "Stock Quantity must be between 0 and 10000.")]
        public int? StockQuantity { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
