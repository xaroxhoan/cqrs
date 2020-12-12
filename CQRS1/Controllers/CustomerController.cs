using Application.CustomerCQ.Commands.Delete;
using Application.CustomerCQ.Commands.Upsert;
using Application.CustomerCQ.Queries.List;
using Application.CustomerCQ.Queries.Single;
using DataLayer.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS1.Controllers
{
    //[Route("api/[controller]")]
   // [ApiController]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/customer/upsert")]
        public async Task<ActionResult> Upsert([FromBody] UpsertCustomerCmd request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("api/customer/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var request = new DeleteCustomerCmd 
            {
                Id = id
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/customer/single/{id}")]
        public async Task <IActionResult> Single([FromRoute] int id)
        {
            var request = new SingleCustomerQuery
            {
                Id=id

            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/customer/list")]
        public async Task<IActionResult>  List([FromQuery] ListCustomerQuery request)
        {
            return Ok(await _mediator.Send(request));
        }




    }
}
