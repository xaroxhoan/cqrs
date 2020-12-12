using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.OrderCQ.Queries.Single
{
   public  class SingleOrder:IRequest<Response<SingleOrderDto>>
    {

    }

    public class SingleOrderHandler : IRequestHandler<SingleOrderQuery, Response<SingleOrderDto>> 
    {
         public async Task<Response<SingleOrderDto>> Handle(SingleOrderQuery request, CancellationToken cancellationToken)
        {
         
                var order = await _context.Orders.SingleOrDefaultAsync(z => z.Id == request.Id);
                var dto = new SingleOrderDto()
                {
                     
                   
                    DateOrder=order.DateOrder,
                    DateSend=order.DateSend
                };

            return new Response<SingleOrderDto>
            {
                Status = true,
                Message = "return Specified Recorded ",
                Data=dto
            };
           
        }

        private readonly DataBaseContext _context;
        public SingleOrderHandler(DataBaseContext  context)
        {
            _context = context;
        }

       
    }
}
