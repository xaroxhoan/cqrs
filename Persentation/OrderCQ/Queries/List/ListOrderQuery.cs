using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OrderCQ.Queries.List
{
   public  class ListOrderQuery : IRequest<Response<IList<ListOrderDto>>>
    {
        
        public string Name { get; set; }
       
        public DateTime MinDateOrder { get; set; }
        public DateTime MaxDateOrder { get; set; }
        public DateTime MinDateSend { get; set; }
        public DateTime MaxDateSend { get; set; }
    }
}
