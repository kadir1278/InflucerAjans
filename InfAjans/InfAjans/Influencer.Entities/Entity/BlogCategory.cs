using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class BlogCategory:LittleEntity
    {
        public BlogCategory()
        {
            this.Blogs = new HashSet<Blog>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LangTableID { get; set; }
        public LangTable LangTable { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
