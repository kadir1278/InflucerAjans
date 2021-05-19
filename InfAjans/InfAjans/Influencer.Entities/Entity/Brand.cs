using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Brand:HighEntity
    {
        public Brand()
        {
            this.BrandImages = new HashSet<BrandImage>();
            this.APIs = new HashSet<API>();
        }
        public string Name { get; set; }
        public string Content { get; set; }
        public string LogoPath { get; set; }
        public string ShortContent { get; set; }
        public int LangTableID { get; set; }
        public LangTable LangTable { get; set; }


        public virtual ICollection<BrandImage> BrandImages { get; set; }
        public virtual ICollection<API> APIs { get; set; }

    }
}
