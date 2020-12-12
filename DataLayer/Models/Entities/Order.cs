using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
       
       // public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateSend { get; set; }
        //---------------------
        public int CustomerId { get; set; }
        public Customer  Customer   { get; set; }
        //----------------------------
        public IList<OrderDetail>  OrderDetails { get; set; }

    }
}
