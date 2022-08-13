using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Application.Interfaces;
using News.Application.Models;
using News.Application.New.Commands;
using News.Application.New.Commands.CreateNewsCommands;
using News.Application.New.Commands.EditNewsCommands;
using News.Application.New.Queires;
using News.Application.New.Queires.GetNewsQueries;
using News.Domain.Entities;

namespace News.Api.Controllers.NewsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseApiController
    {

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNews(CreateNewsCommand commad)
        {
            return HandleResult(await Mediator.Send(commad)); 
        }

        [HttpGet]
        public async Task<IActionResult> GetNews([FromQuery]PagingParams pageparams)
        {
            return HandlePagedResult(await Mediator.Send(new GetNewsQuery { pagingParams = pageparams }));
        }
        [HttpGet]
        public async Task<IActionResult> GetNewsState([FromQuery] PagingParams pageparams)
        {
            return HandlePagedResult(await Mediator.Send(new GetNewsStateQuery { pagingParams = pageparams }));
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditNews(EditNewsCommand editNews)
        {
            return HandleResult(await Mediator.Send(editNews));
        }
    }
}
