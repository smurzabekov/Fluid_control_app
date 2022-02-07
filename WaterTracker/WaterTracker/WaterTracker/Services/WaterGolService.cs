using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WaterTracker.Models;
using Xamarin.Forms.Internals;

namespace WaterTracker.Services
{
    class WaterGolService
    {        
        private static readonly int[] weightArray = { 50, 60, 70, 80, 90, 100 };
        private static readonly int[] low = { 1550, 1850, 2200, 2500, 2800, 3100 };
        private static readonly int[] hight = { 2000, 2300, 2550, 2950, 3300, 3600 };
        public static int GetGol(bool isSportsmen,bool isWomen,int weight)
        {
            int index = weightArray.IndexOf(Find(weightArray, weight));
            int result = isSportsmen ? hight[index] : low[index];
            return isWomen ? result - 500 : result;
        }

        private static int Find(int[] arj, int x)
        {
            int min = arj[0];
            foreach (int n in arj)
            {
                if ((Math.Abs(n - x)) < (Math.Abs(x - min)))
                    min = n;
            }
            return min;
        }

        public static double GetDrinkCoef(Drink.Types drinkType)
        {
            var type = typeof(Drink.Types);
            var memInfo = type.GetMember(type.GetEnumName(drinkType));
            var descriptionAttribute = memInfo[0]
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .First() as DescriptionAttribute;

            return double.Parse(descriptionAttribute.Description);
        }
    }
}
