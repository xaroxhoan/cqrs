using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
