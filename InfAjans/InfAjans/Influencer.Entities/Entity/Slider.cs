using Influencer.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Influencer.Entities.Entity
{
    public class Slider:LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageVideoPath { get; set; }
     
        public int MainSliderID { get; set; }
        public MainSlider MainSlider { get; set; }
    }
}
