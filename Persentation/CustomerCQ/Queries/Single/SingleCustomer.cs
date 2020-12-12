using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.CustomerCQ.Queries.Single
{
    public class SingleCustomer:IRequest<Response<SingleCustomerDto>>
    {

    }

    public class SingleCustomerHandeler : IRequestHandler<SingleCustomerQuery, Response<SingleCustomerDto>>
    {
        public async Task<Response<SingleCustomerDto>> Handle(SingleCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id==request.Id);
            var dto = new SingleCustomerDto()
            {
                Id = customer.Id,
                Name=customer.Name,
                Age=customer.Age

            };
            
            
            
            return new Response<SingleCustomerDto>
            {
                Status = true,
                Message = "one record Finded"
            };
        }

        private readonly DataBaseContext _context;
        public SingleCustomerHandeler(DataBaseContext  context)
        {
            _context = context;
        }
    }
}
