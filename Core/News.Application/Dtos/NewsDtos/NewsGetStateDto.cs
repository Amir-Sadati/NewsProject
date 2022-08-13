using News.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Dtos.NewsDtos
{
    public class NewsGetStateDto
    {
        public string Ttile { get; set; }
        public string Description { get; set; }
        public string UsersDisplayName { set; get; }
        public List<string> Photos { get; set; }
        public State State { set; get; }
    }
}
