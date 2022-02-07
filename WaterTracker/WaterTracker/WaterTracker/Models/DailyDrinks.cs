using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterTracker.Models
{
    class DailyDrinks
    {
        public DateTime dateTime { get; set; }

        public string dateTimeString => dateTime.ToString("MM/dd/yyyy");

        public IList<Drink> drinks { get; set; }

        public string sum => $"{drinks.Sum(x => x.ValueInMilliliters)}ml";
    }
}
