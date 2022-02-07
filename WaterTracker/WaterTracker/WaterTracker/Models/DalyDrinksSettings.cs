using System;
using System.Collections.Generic;
using System.Text;

namespace WaterTracker.Models
{
    class DalyDrinksSettings : BaseEntity
    {
        public bool IsSportsman { get; set; }

        public bool Sex { get; set; }

        public int Weight { get; set; }
    }
}
