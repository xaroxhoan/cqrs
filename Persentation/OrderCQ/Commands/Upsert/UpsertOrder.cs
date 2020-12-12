using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using DataLayer.Models.Context;
using DataLayer.Models.Entities;

namespace Application.OrderCQ.Commands.Upsert
{
    public class UpsertOrder:IRequest<Response<UpsertOrderDto>>
    {

    }

    public class UpserOrderHandler : IRequestHandler<UpsertOrderCmd, Response<UpsertOrderDto>>
{
        public async Task<Response<UpsertOrderDto>> Handle(UpsertOrderCmd request, CancellationToken cancellationToken)
        {
           var order = new Order();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);
            if (request.Id!=0)
            {
                // fetching customer
                order = await _context.Orders.SingleOrDefaultAsync(x => x.Id == request.Id);
                 
                order.DateOrder = request.DateOrder;
                order.DateSend = request.DateSend;
                order.Customer = customer;
                //_context.Orders.Update(order);
            }
           else
            {
                 
                order.DateOrder = request.DateOrder;
                order.DateSend = request.DateSend;
                order.Customer = customer;
                _context.Orders.Add(order);
            }


            // fetching product
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);

            // creating new order details
            var orderDetail = new OrderDetail
            {
                Order = order,
                Product = product,
                Quantity = request.Quantity
            };

            _context.OrderDetails.Add(orderDetail);
 

            await _context.SaveChangesAsync();
            return new Response<UpsertOrderDto>
            {
                Status = true,
                Message = "Upsert   ok"
                
            };
        }

        private readonly DataBaseContext _context;
        public UpserOrderHandler(DataBaseContext context)
        {
            _context = context;
        }
    }
}
