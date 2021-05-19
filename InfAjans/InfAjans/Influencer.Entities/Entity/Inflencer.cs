using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Inflencer : HighEntity
    {
        public Inflencer()
        {
            this.InfluencerVideos = new HashSet<InfluencerVideo>();
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
        public int LangTableID { get; set; }
        public LangTable LangTable { get; set; }

        public virtual ICollection<InfluencerVideo> InfluencerVideos { get; set; }

    }
}
