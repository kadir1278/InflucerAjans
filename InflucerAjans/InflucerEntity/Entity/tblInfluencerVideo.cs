using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblInfluencerVideo:LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string InfluencerVideoPath { get; set; }
        public int InfluencerID { get; set; }
        public tblInfluencer tblInfluencer { get; set; }

    }
}
