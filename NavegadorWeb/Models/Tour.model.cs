﻿using System.Collections.Generic;

namespace NavegadorWeb.Models
{
    public class Tour
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public int user_id { get; set; }
        public List<Step> steps { get; set; }
    }
}
