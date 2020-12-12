using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ProductCQ.Queries.List
{
    public class ListProductQuery : IRequest<Response<IList<ListProductDto>>>
    {
        public int cateId { get; set; }

        public string Name { get; set; }
        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }
    }
}
