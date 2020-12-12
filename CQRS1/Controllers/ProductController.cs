
using Application.ProductCQ.Commands.Delete;
using Application.ProductCQ.Commands.Upsert;
using Application.ProductCQ.Queries.List;
using Application.ProductCQ.Queries.Single;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CQRS1.Controllers
{
    // [Route("[controller]")]
    //[ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost("api/product/upsert")]
        public async Task<IActionResult> Upsert([FromBody] UpsertProductCmd request)
        {
            // var request = new UpsertProductCmd();
            return Ok(await _mediator.Send(request));
        }

         [HttpDelete("api/product/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var request = new DeleteProductCmd
            {
                Id = id
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/product/single/{id}")]
        public async Task<IActionResult> Single([FromRoute] int id)
        {
            var request = new SingleProductQuery
            {
                Id = id
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("api/product/List")]
        public async Task<IActionResult> List([FromQuery] ListProductQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
