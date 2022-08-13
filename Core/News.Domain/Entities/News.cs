using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Domain.Entities
{
    public enum State
    {
        WaitForPublish,
        Publish,
        Deleted,
        
    }
    public class News : BaseEntities
    {
        public string Ttile { get; set; }
        public string Description { get; set; }
        public int UsersId { set; get; }
        public  Users Users { get; set; }
        public int? ApproveById { set; get; }  
        public State State { set; get; }
        public List<Photos> Photos { get; set; }


    }
}
