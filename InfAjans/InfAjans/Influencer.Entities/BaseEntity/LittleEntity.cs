using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.BaseEntity
{
    public class LittleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime LastDateTime { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; }
    }
}
