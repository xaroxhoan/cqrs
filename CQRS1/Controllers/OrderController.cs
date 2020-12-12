using Application.OrderCQ.Commands.Delete;
using Application.OrderCQ.Commands.Upsert;
using Application.OrderCQ.Queries.List;
using Application.OrderCQ.Queries.Single;
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
    //[ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator  mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/order/upsert")]
        public async Task<IActionResult> Upsert ([FromBody]UpsertOrderCmd request)
        {
            return Ok (await _mediator.Send(request));
        }

        [HttpDelete("api/order/delete/{id}")]
        public async Task<IActionResult> Delete([FromHeader] int id)
        {
            var request = new DeleteOrderCmd
            {
                Id = id
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/order/single/{id}")]
        public async Task<IActionResult> Single([FromRoute]int id)
        {
            var request = new SingleOrderQuery
            {
                Id = id
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/order/list")]
        public async Task<IActionResult> List ([FromQuery]ListOrderQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
