using InflucerEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflucerEntity.Entity
{
    public class tblAPI:LittleEntity
    {
        public string Key { get; set; }
        public string SecretKey { get; set; }
        public string Title { get; set; }

    }
}
