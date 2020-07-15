using System.Collections.Generic;

namespace NavegadorWeb.Models
{
    public class Step
    {
        public string url { get; set; }
        public string audio_url { get; set; }
        public int order { get; set; }
        public List<Element> elements { get; set; }
    }
}
