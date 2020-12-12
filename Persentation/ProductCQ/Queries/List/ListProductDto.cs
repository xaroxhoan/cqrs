using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCQ.Queries.List
{
    public class ListProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Models { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
