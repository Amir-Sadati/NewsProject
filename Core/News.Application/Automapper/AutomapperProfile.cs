using AutoMapper;
using News.Application.Dtos.NewsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<News.Domain.Entities.News, NewsGetStateDto>();

        }
    }
}
