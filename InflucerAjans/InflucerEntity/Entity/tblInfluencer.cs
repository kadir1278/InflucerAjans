using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblInfluencer : HighEntity
    {
        public tblInfluencer()
        {
            this.tblInfluencerVideos = new HashSet<tblInfluencerVideo>();
        }
        public string InfluencerCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InstagramAddress { get; set; }
        public string FacebookAddress { get; set; }
        public string TwitterAddress { get; set; }
        public int InstagramFollower { get; set; }
        public int FacebookFollower { get; set; }
        public int TwitterFollower { get; set; }
        public int LangID { get; set; }
        public tblLang tblLang { get; set; }

        public virtual ICollection<tblInfluencerVideo> tblInfluencerVideos { get; set; }

    }
}
