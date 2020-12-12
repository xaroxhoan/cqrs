using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.ProductCQ.Commands.Delete
{
    public class DeleteProduct : IRequest<Response<DeleteProductDto>>
    {
    }


    public class DeleteProductHandler : IRequestHandler<DeleteProductCmd, Response<DeleteProductDto>>
    {
        public async Task<Response<DeleteProductDto>> Handle(DeleteProductCmd request, CancellationToken cancellationToken)
        {
            if (request.Id!=0)
           {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
                 _context.Remove(product); 
                await _context.SaveChangesAsync();
          }
          
            return new Response<DeleteProductDto>
            {
                Status= true,
                Message = "product delete success",
               
            };
        }



        private readonly DataBaseContext _context;

        public DeleteProductHandler(DataBaseContext context)
        {
            _context = context;
        }
    }
}
 