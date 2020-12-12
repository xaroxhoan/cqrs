using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
     public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IList<Address> Addresses { get; set; }
        public IList<Order>  Orders { get; set; }
    }
}
