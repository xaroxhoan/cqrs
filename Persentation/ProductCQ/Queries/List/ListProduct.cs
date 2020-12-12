using DataLayer.Models.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace Application.ProductCQ.Queries.List
{
    public class ListProduct : IRequest<Response<IList<ListProductDto>>>
    {
    }

    public class ListProductHandler : IRequestHandler<ListProductQuery, Response<IList<ListProductDto>>>
    {
        public async Task<Response<IList<ListProductDto>>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            var list = _context.Products.AsQueryable();


            if (!string.IsNullOrEmpty(request.Name))
            {
                list = list.Where(p => p.Name == request.Name).AsQueryable();
            }

            if (request.cateId != 0)
            {
                list = list.Where(p => p.CategoryId == request.cateId).AsQueryable();
            }

            list = list.Where(p => p.Price <= request.MaxPrice && p.Price >= request.MinPrice).AsQueryable();

            var finalList = await list.Select(p => new ListProductDto() {
                Id = p.Id,
                Category=p.Category.Tite,
                Name=p.Name,
                Models=p.Model,
                Price=p.Price,
                Quantity=p.Quantity

            }).ToListAsync(); 

            return new Response<IList<ListProductDto>>
            {
                Status = true,
                Message ="List return ok",
                Data = finalList
            };
        }

         
               
              

    private readonly DataBaseContext _context;
        public ListProductHandler(DataBaseContext context)
        {
            _context = context;
        }
    }
}
