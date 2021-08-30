using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAPI.model
{
    public class Laws
    {


        public int techID { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int paragraph { get; set; }
        public string titel { get; set; }
        public string refT { get; set; }
        public int isSameLawref { get; set; }
        public int isRefQK { get; set; }
        public string isTitleRelevant { get; set; }
        public string isTitleRefRelevant { get; set; }




    }
}
