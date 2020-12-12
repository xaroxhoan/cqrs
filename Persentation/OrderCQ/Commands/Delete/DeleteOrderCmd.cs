using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.OrderCQ.Commands.Delete
{
   public  class DeleteOrderCmd:IRequest<Response<DeleteOrderDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateSend { get; set; }
        //---------------------
        public int CustomerId { get; set; }
    }
}
