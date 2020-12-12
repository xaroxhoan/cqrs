using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.ProductCQ.Queries.Single
{
    public class SingleProduct:IRequest<Response<SingleProductDto>>
    {

    }

    public class SingleProductHandler : IRequestHandler<SingleProductQuery, Response<SingleProductDto>>
    {
        public async Task<Response<SingleProductDto>> Handle(SingleProductQuery request, CancellationToken cancellationToken)
        {


            var singleProduct = await _context.Products.Include(x=>x.Category).FirstOrDefaultAsync(p => p.Id == request.Id);
            
            var dto = new SingleProductDto()
            {
                Id = singleProduct.Id,
                Category = singleProduct.Category.Tite,
                Name = singleProduct.Name,
                Models = singleProduct.Model,
                Price = singleProduct.Price,
                Quantity = singleProduct.Quantity

            };

            return new Response<SingleProductDto>
            {
                Status = true,
                Message = "Single Product return ok",
                Data = dto 
            };
        }

        private readonly DataBaseContext _context;
        public SingleProductHandler(DataBaseContext  context)
        {
            _context = context;
        }
    }


}
 