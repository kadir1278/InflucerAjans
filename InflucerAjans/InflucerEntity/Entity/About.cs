using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class About:LightEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageVideUrl { get; set; }
        public string ImageVideoAlt { get; set; }
    }
}
