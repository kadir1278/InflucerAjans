using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Blog:LittleEntity
    {
        public Blog()
        {
            this.BlogDetails = new HashSet<BlogDetail>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string ShortContent { get; set; }
        public int BlogCategoryID { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public virtual ICollection<BlogDetail> BlogDetails { get; set; }
    }
}
