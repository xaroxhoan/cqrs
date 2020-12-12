using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using DataLayer.Models.Context;
using System.Linq;

namespace Application.CustomerCQ.Queries.List
{
    public class ListCustomer : IRequest<Response<IList<ListCustomerDto>>>
    {
    }

    public class ListCustomerHandler : IRequestHandler<ListCustomerQuery, Response<IList<ListCustomerDto>>>
    {
        public async Task<Response<IList<ListCustomerDto>>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
        {
           // var list2 = await _context.Customers.ToListAsync();
            var list  = _context.Customers.AsQueryable();
            if (!string.IsNullOrEmpty(request.Id.ToString()))
            {
                list = list.Where(x => x.Id == request.Id).AsQueryable();
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                list = list.Where(x => x.Name == request.Name).AsQueryable();
            }
            if (!string.IsNullOrEmpty(request.MaxAge.ToString()) && !string.IsNullOrEmpty(request.MinAge.ToString()))
            {

                list = list.Where(x => x.Age <= request.MaxAge && x.Age >= request.MinAge).AsQueryable();
            }

            var finalList =await list.Select(c => new ListCustomerDto()
            {
                Id=c.Id,
                Name=c.Name,
                Age=c.Age
            }).ToListAsync();

            return  new  Response<IList<ListCustomerDto>>
            {
                Status = true,
                Message = "List return ok",
              //Data = (IList<ListCustomerDto>)list2
               Data =  finalList
            };

        }

        private readonly DataBaseContext _context;
        public ListCustomerHandler(DataBaseContext context)
        {
            _context = context;
        }

    }
}
