using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CategoryCQ.Commands.Upsert
{
    public class UpsertCategoryCmd : IRequest<Response<UpsertCategoryDto >>
    {
        public int Id { get; set; }

        public string Tite { get; set; }
        public int? ParentId { get; set; }
    }
}
