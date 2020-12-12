using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerCQ.Commands.Upsert
{
   public class UpsertCustomerCmd:IRequest<Response<UpsertCustomerDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
