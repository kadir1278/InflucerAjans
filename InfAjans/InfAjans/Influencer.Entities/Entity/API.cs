using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Influencer.Entities.BaseEntity;


namespace Influencer.Entities.Entity
{
    public class API:LittleEntity
    {
        public string Key { get; set; }
        public string SecretKey { get; set; }
        public string Title { get; set; }

    }
}
