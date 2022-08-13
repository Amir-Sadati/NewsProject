using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities
{
    public class Photos :BaseEntities
    {
        public int NewsId { get; set; }
        public News News { get; set; }
        public string Url { get; set; }
    }
}
