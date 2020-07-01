using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegadorWeb.Models
{
    public class Element
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int StepId { get; set; }
    }
}
