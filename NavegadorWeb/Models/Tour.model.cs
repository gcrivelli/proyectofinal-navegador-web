using System.Collections.Generic;

namespace NavegadorWeb.Models
{
    public class Tour
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public string user_id { get; set; }
        public List<Step> steps { get; set; }
    }
}
