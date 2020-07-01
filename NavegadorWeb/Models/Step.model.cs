using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AudioUrl { get; set; }
        public int Order { get; set; }
        public int TourId { get; set; }
    }
}
