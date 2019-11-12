using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyGo.ViewModels
{
    public class TopTravelViewModel
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Time { get; set; }
        public string Country { get; set; }
        public string Images { get; set; }
        public int Cost { get; set; }
    }
}