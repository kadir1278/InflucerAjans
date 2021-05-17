using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblInNew : HighEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
