using Influencer.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Model
{
    public class InfluencerContext : DbContext
    {
        public InfluencerContext() : base("Ajans")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<UserMember> UserMembers { get; set; }
        public DbSet<InNew> InNews { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<API> APIs { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }
        public DbSet<Inflencer> Inflencers { get; set; }
        public DbSet<InfluencerVideo> InfluencerVideos { get; set; }
        public DbSet<LangTable> Langs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<MainGoogleSeo> MainGoogleSeos { get; set; }
        public DbSet<MainSlider> MainSliders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
