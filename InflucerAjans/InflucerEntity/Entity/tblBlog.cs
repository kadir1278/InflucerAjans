using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblBlog:HighEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string ShortContent { get; set; }
        public int LangID { get; set; }
        public tblLang tblLang { get; set; }

    }
}
