using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
    public class OrderDetailProduct
    {
      // public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }

        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }
    }
}
