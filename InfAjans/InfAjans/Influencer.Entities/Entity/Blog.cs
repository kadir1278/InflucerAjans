using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Blog:HighEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string ShortContent { get; set; }
        public int LangTableID { get; set; }
        public LangTable LangTable { get; set; }

    }
}
