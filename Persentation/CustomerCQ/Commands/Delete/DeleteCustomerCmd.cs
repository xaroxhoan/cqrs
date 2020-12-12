using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerCQ.Commands.Delete
{
    public class DeleteCustomerCmd : IRequest<Response<DeleteCustomerDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
