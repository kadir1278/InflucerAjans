using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class InfluencerVideo:LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string InfluencerVideoPath { get; set; }
        public int InfluencerID { get; set; }
        public Inflencer Influencer { get; set; }

    }
}
