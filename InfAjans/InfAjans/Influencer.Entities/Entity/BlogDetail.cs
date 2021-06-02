using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class BlogDetail:LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
