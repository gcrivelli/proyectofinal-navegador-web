using System.Collections.Generic;

namespace NavegadorWeb.Models
{
    public class Step
    {
        public string _id { get; set; }
        public string url { get; set; }
        public int order { get; set; }
        public string audio { get; set; }
        public List<Element> elements { get; set; }
    }
}
