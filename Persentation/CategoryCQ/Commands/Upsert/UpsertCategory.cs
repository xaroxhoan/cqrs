using DataLayer.Models.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.CategoryCQ.Commands.Upsert
{
    public class UpsertCategory : IRequest<Response<UpsertCategoryDto>>
    {

    
    }

    public class UpsertCategoryHandeler : IRequestHandler<UpsertCategoryCmd, Response<UpsertCategoryDto>>
    {
        


        private readonly DataBaseContext _context;
        public UpsertCategoryHandeler(DataBaseContext context)
        {
            _context = context;
        }

        public Task<Response<UpsertCategoryDto>> Handle(UpsertCategoryCmd request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


}
