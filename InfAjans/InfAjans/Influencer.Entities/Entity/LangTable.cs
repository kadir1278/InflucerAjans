using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class LangTable : LittleEntity
    {
        public LangTable()
        {
            this.MainSliders = new HashSet<MainSlider>();
            this.Services = new HashSet<Service>();
            this.Influencers = new HashSet<Inflencer>();
            this.Brands = new HashSet<Brand>();
            this.ApplicationForms = new HashSet<ApplicationForm>();
            this.Abouts = new HashSet<About>();
            this.Blogs = new HashSet<Blog>();
            this.InNews = new HashSet<InNew>();
            this.MainGoogleSeos = new HashSet<MainGoogleSeo>();



        }
        public string LangName { get; set; }
        public string LangCode { get; set; }

        public virtual ICollection<MainGoogleSeo> MainGoogleSeos { get; set; }

        public virtual ICollection<InNew> InNews { get; set; }

        public virtual ICollection<MainSlider> MainSliders { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Inflencer> Influencers { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ApplicationForm> ApplicationForms{get; set;}
        public virtual ICollection<About> Abouts { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
