using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCQ.Commands.Upsert
{
    public class UpsertProductCmd:IRequest<Response<UpsertProductDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
