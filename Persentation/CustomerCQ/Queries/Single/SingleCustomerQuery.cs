using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerCQ.Queries.Single
{
    public class SingleCustomerQuery : IRequest<Response<SingleCustomerDto>>
    {
        public int Id { get; set; }
    }
}
