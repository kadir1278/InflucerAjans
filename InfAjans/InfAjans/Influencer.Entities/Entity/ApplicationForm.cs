using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class ApplicationForm:LittleEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
