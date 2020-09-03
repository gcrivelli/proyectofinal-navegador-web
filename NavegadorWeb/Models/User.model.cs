using System.Collections.Generic;

namespace NavegadorWeb.Models
{
    public class User
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Tour> tours { get; set; }
        public string rol { get; set; }
    }
}
