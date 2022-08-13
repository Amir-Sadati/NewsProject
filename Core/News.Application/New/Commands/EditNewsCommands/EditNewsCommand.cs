using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Application.Models;
using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.New.Commands.EditNewsCommands
{
    public class EditNewsCommand : IRequest<Result<Unit>>
    {
        public string Ttile { get; set; }
        public int NewsId { set; get; }
        public string Description { get; set; }
        public List<string> Images { set; get; }
        public State State { set; get; }
    }

    public class EditNewsCommandHandler : IRequestHandler<EditNewsCommand, Result<Unit>>
    {
        private readonly IDataContext _context;

        public EditNewsCommandHandler(IDataContext context)
        {
            _context = context;
        }
        public async Task<Result<Unit>> Handle(EditNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News.Include(x => x.Photos).SingleOrDefaultAsync(cancellationToken);
            if (news==null)
                return Result<Unit>.Failure("User Not Found");
            news.Ttile = request.Ttile;
            news.Description = request.Description;
            news.Photos = request.Images.Select(x => new Photos { Url = x }).ToList();
            news.State= request.State;
            //news.ApproveById= Id User Login

            if (_context.SaveChanges() > 0)
                return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("error occur");

        }
    }


}
