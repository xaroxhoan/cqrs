using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCQ.Queries.Single
{
    public class SingleProductQuery:IRequest<Response<SingleProductDto>>
    {

        public int Id { get; set; }

    }
}
