using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.OrderCQ.Commands.Delete
{
   public  class DeleteOrder: IRequest<Response<DeleteOrderDto>>
    {
    }
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCmd, Response<DeleteOrderDto>>
    {
        public async Task<Response<DeleteOrderDto>> Handle(DeleteOrderCmd request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {
                var order = await _context.Orders.SingleOrDefaultAsync(x => x.Id == request.Id);
                _context.Remove(order);

            }
            await _context.SaveChangesAsync();
            return new Response<DeleteOrderDto>
            {
                Status = true,
                Message = "Delete record Success"
            };
 
        }

        private readonly DataBaseContext _context;
    
        public DeleteOrderHandler(DataBaseContext context)
        {
            _context = context;
        }
    }
}
