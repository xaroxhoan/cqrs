using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models.Entities;

namespace Application.CustomerCQ.Commands.Upsert
{
    public class UpsertCustomer : IRequest<Response<UpsertCustomerDto>>
    {
    }

    public class UpsertCustomerHandler : IRequestHandler<UpsertCustomerCmd, Response<UpsertCustomerDto>>
    {
        public async Task<Response<UpsertCustomerDto>> Handle(UpsertCustomerCmd request, CancellationToken cancellationToken)
        {
            if (request.Id!=0)
            {
                var customer =await _context.Customers.SingleOrDefaultAsync(c => c.Id == request.Id);
                customer.Name = request.Name;
                customer.Age = request.Age;
                _context.Update(customer);
             
            }
            else
            {
                await _context.Customers.AddAsync(new Customer
                {
                    Name=request.Name,
                    Age=request.Age
                });
                
            }
           await  _context.SaveChangesAsync();
            return  new Response<UpsertCustomerDto>
            {
                Status = true,
                Message = "Add or Edit new Record Success "
            };
        }

        private readonly DataBaseContext _context;
        public UpsertCustomerHandler(DataBaseContext context)
        {
            _context = context;
        }
    }

}
