using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using News.Application.Dtos;
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
    public class GetNewsStateQuery : IRequest<Result<PagedList<NewsGetStateDto>>>
    {
        public PagingParams pagingParams { set; get; }
    }

    public class GetNewsStateQueryHandler : IRequestHandler<GetNewsStateQuery, Result<PagedList<NewsGetStateDto>>>
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;

        public GetNewsStateQueryHandler(IDataContext context , IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<PagedList<NewsGetStateDto>>> Handle(GetNewsStateQuery request, CancellationToken cancellationToken)
        {
          var news=  _context.News.Where(x => x.State != Domain.Entities.State.Publish)
                .ProjectTo<NewsGetStateDto>(_mapper.ConfigurationProvider).AsQueryable();

               return Result<PagedList<NewsGetStateDto>>.Success(
                   await PagedList<NewsGetStateDto>.CreateAsync(news, request.pagingParams.PageNumber,
                       request.pagingParams.PageSize));



        }
    }
}
