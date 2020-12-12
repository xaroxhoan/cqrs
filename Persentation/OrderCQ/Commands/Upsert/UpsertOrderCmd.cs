using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OrderCQ.Commands.Upsert
{
   public class UpsertOrderCmd:IRequest<Response<UpsertOrderDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateSend { get; set; }
        //---------------------
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
