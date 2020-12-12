using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Tite { get; set; }
        public int? ParentId { get; set; }
        public Category  Parent { get; set; }
        public List<Category> Parents { get; set; }

        public List<Product> Products { get; set; }
    }
}
