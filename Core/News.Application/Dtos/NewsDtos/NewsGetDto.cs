using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Dtos.NewsDtos
{
    public class NewsGetDto
    {
        public string Ttile { get; set; }
        public string Description { get; set; }
        public string Writer { set; get; }
        public List<string> Photos { get; set; }
    }
}
