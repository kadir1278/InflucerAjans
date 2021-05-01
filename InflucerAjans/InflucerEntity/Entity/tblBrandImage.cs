using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblBrandImage:LittleEntity
    {
        public string BrandImagePath { get; set; }
        public int BrandID { get; set; }
        public tblBrand tblBrand { get; set; }

    }
}
