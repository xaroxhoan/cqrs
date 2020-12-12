using DataLayer.Models.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CustomerCQ.Commands.Delete
{
    public class DeleteCustomer:IRequest<Response<DeleteCustomerDto>>
    {

    }
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCmd, Response<DeleteCustomerDto>>
    {
        public async  Task<Response<DeleteCustomerDto>> Handle(DeleteCustomerCmd request, CancellationToken cancellationToken)
        {
            if (request.Id!=0)
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == request.Id);
                _context.Customers.Remove(customer);
            }
          
            await _context.SaveChangesAsync();
            return new Response<DeleteCustomerDto>
            {
                Status = true,
                Message = "Delete record Success"
            };
        }

        private readonly DataBaseContext _context;
        public DeleteCustomerHandler(DataBaseContext context)
        {
            _context = context;
        }

        
    }
}
