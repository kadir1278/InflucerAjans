using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class SocialMedia : LittleEntity
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
    }
}
