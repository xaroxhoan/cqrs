using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using MediatR;
using DataLayer.Models.Context;
using DataLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.ProductCQ.Commands.Upsert
{
    public class UpsertProduct : IRequest<Response<UpsertProductDto>>
    {

    }
    public class UpsertProductHandler : IRequestHandler<UpsertProductCmd, Response<UpsertProductDto>>
    {
        public async Task<Response<UpsertProductDto>> Handle(UpsertProductCmd request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
                product.Model = request.Model;
                product.Name = request.Name;
                product.Price = request.Price;
                product.Quantity = request.Quantity;

                product.CategoryId = request.CategoryId;
                _context.Products.Update(product);
                
            }
            else
            {
              
               await _context.Products.AddAsync(new  Product
               {
                    Model = request.Model,
                    Name = request.Name,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    CategoryId = request.CategoryId 
            });
            }
            await _context.SaveChangesAsync();
            return new Response<UpsertProductDto>
            {
                Status = true,
                Message = "data register success"
            };
        }
        private readonly DataBaseContext _context;
        public UpsertProductHandler(DataBaseContext context)
        {
            _context = context;
        }




    }
}



