using InflucerEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Model
{
    public class InfluencerContext : DbContext
    {
        public InfluencerContext() : base("Influencer")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<tblAbout> tblAbouts { get; set; }
        public DbSet<tblAPI> tblAPIs { get; set; }
        public DbSet<tblApplicationForm> tblApplicationForms { get; set; }
        public DbSet<tblBrand> tblBrands { get; set; }
        public DbSet<tblBrandImage> tblBrandImages { get; set; }
        public DbSet<tblInfluencer> tblInfluencers { get; set; }
        public DbSet<tblInfluencerVideo> tblInfluencerVideos { get; set; }
        public DbSet<tblLang> tblLangs { get; set; }
        public DbSet<tblService> tblServices { get; set; }
        public DbSet<tblSlider> tblSliders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
