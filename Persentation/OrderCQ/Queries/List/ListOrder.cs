using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.OrderCQ.Queries.List
{
   public  class ListOrder:IRequest<Response<IList<ListOrderDto >>>
    {

    }

    public class ListOrderHandler : IRequestHandler<ListOrderQuery, Response<IList<ListOrderDto>>>
    {
      

        public async Task<Response<IList<ListOrderDto>>> Handle(ListOrderQuery request, CancellationToken cancellationToken)
        {
            var list = _context.Orders.AsQueryable();
            var finalList =await list.ToListAsync();

            return new Response<IList<ListOrderDto>>
            {
                Status = true,
                Message = "List return Ok",
                Data = (IList<ListOrderDto>)finalList
            };
        }

        private readonly DataBaseContext _context;
        public ListOrderHandler(DataBaseContext  context)
        {
            _context = context;
        }
    }
}
