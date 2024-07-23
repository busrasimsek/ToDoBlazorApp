namespace ToDoBlazorApp.Data
{
    public class Category : BaseEntity
    {
        //public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
