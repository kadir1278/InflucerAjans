using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class BrandImage:LittleEntity
    {
        public string BrandImagePath { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }

    }
}
