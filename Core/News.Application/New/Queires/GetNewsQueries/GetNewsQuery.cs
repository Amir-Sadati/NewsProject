using MediatR;
using News.Application.Dtos.NewsDtos;
using News.Application.Interfaces;
using News.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.New.Queires.GetNewsQueries
{
    public class GetNewsQuery : IRequest<Result<PagedList<NewsGetDto>>>
    {
        public PagingParams pagingParams { set; get; }
    }


    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, Result<PagedList<NewsGetDto>>>
    {
        private readonly IDataContext _context;

        public GetNewsQueryHandler(IDataContext context)
        {
            _context = context;
        }
        public async Task<Result<PagedList<NewsGetDto>>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var news = _context.News.Where(x => x.State == Domain.Entities.State.Publish).Select(x => new NewsGetDto
            {
                Description = x.Description,
                Photos = x.Photos.Select(x => x.Url).ToList(),
                Ttile = x.Ttile,
                Writer = x.Users.DisplayName
            }
              ).AsQueryable();
            return Result<PagedList<NewsGetDto>>.Success(
                   await PagedList<NewsGetDto>.CreateAsync(news, request.pagingParams.PageNumber,
                       request.pagingParams.PageSize));

        }
    }
}
