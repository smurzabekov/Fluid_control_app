using System;
using System.Collections.Generic;
using System.Text;

namespace WaterTracker.Models
{
    class UserSettings : BaseEntity
    {
        public TimeSpan DateFrom { get; set; }

        public TimeSpan DateTo { get; set; } 

        public int Every { get; set; }

        public bool NotificationEnable { get; set; }
    }
}
