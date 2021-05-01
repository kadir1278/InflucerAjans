using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblService : HighEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageVideoPath { get; set; }
        public string ShortContent { get; set; }

    }
}
