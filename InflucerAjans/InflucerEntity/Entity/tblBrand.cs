using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblBrand:HighEntity
    {
        public tblBrand()
        {
            this.tblBrandImages = new HashSet<tblBrandImage>();
            this.tblAPIs = new HashSet<tblAPI>();
        }
        public string Name { get; set; }
        public string Content { get; set; }
        public string LogoPath { get; set; }
        public string ShortContent { get; set; }

        public virtual ICollection<tblBrandImage> tblBrandImages { get; set; }
        public virtual ICollection<tblAPI> tblAPIs { get; set; }

    }
}
