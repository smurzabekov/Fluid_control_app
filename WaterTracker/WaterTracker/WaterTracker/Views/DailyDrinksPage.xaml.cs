using System.Collections;
using System.Collections.Generic;
using WaterTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyDrinksPage : ContentPage
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public DailyDrinksPage(object args)
        {
            InitializeComponent();
            Drinks = (args as DailyDrinks).drinks;
            BindingContext = this;
        }
    }
}