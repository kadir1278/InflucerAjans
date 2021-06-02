using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Contact : LittleEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
    }
}
