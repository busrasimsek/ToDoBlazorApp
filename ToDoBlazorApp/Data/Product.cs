﻿using System.ComponentModel.DataAnnotations;

namespace ToDoBlazorApp.Data
{
    public class Product : BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
