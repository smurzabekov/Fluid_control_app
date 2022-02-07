using SQLite;
using System;
using System.ComponentModel;

namespace WaterTracker.Models
{
    public class Drink : BaseEntity
    {
        public DateTime dateTime { get; set; }

        [Ignore]
        public string time => dateTime.ToString("HH:mm");

        public int ValueInMilliliters { get; set; }

        public Types Type { get; set; }

        public enum Types
        {
            [Description("1")]
            Water,
            [Description("0.8")]
            Juice,
            [Description("0.5")]
            Tea,
            [Description("0.4")]
            Coffe,
            [Description("0.5")]
            Yogurte,
            [Description("0.7")]
            Milk
        }
    }
}
