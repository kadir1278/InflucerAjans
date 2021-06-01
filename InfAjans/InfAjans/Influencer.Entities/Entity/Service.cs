using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Service : HighEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageVideoPath { get; set; }
        public string ShortContent { get; set; }
        public string Icon { get; set; }
        public int LangTableID { get; set; }
        public LangTable LangTable { get; set; }
    }
}
