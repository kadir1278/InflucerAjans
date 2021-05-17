using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblLang : LittleEntity
    {
        public tblLang()
        {
            this.TblSliders = new HashSet<tblSlider>();
            this.TblSliders = new HashSet<tblSlider>();
            this.TblServices = new HashSet<tblService>();
            this.TblInfluencers = new HashSet<tblInfluencer>();
            this.TblBrands = new HashSet<tblBrand>();
            this.TblApplicationForms = new HashSet<tblApplicationForm>();
            this.TblAbouts = new HashSet<tblAbout>();
            this.TblBlogs = new HashSet<tblBlog>();

        }
        public string Lang { get; set; }
        public string LangCode { get; set; }

        public virtual ICollection<tblSlider> TblSliders { get; set; }
        public virtual ICollection<tblService> TblServices { get; set; }
        public virtual ICollection<tblInfluencer> TblInfluencers { get; set; }
        public virtual ICollection<tblBrand> TblBrands { get; set; }
        public virtual ICollection<tblApplicationForm> TblApplicationForms{get; set;}
        public virtual ICollection<tblAbout> TblAbouts { get; set; }
        public virtual ICollection<tblBlog> TblBlogs { get; set; }
    }
}
