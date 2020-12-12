using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerCQ.Queries.List
{
   public  class ListCustomerQuery:IRequest<Response<IList<ListCustomerDto>>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxAge { get; set; }

        public int MinAge { get; set; }
    }
}
