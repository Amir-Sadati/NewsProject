using MediatR;
using News.Application.Interfaces;
using News.Application.Models;
using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace News.Application.New.Commands.CreateNewsCommands
{
    public class CreateNewsCommand : IRequest<Result<Unit>>
    {
        public string Ttile { get; set; }
        public int UserId { set; get; }
        public string Description { get; set; }
        public List<string> Images { set; get; }
    }


    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Result<Unit>>
    {
        private readonly IDataContext _context;

        public CreateNewsCommandHandler(IDataContext context)
        {
            
             _context = context;
           
        }
        public async Task<Result<Unit>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new Domain.Entities.News()
            {
                Description = request.Description.Trim(),
                Ttile = request.Ttile.Trim(),
                State = Domain.Entities.State.WaitForPublish,
                Photos = request.Images.Select(x => new Photos() { Url = x }).ToList(),
                //Users=request.UserId
            };

            _context.News.Add(news);
            if ( _context.SaveChanges() > 0)
            return Result<Unit>.Success(Unit.Value);
            return Result<Unit>.Failure("problem happening");
            
        }
    }
}
