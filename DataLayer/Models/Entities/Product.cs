using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        
        public double  Price { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
