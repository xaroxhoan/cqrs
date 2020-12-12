using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OrderCQ.Queries.Single
{
   public  class SingleOrderQuery : IRequest<Response<SingleOrderDto>> 
    {

        public int Id { get; set; }

    }
}
