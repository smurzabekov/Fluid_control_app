using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using WaterTracker.CustomControls;
using WaterTracker.Models;
using WaterTracker.Services;
using Xamarin.Forms;

namespace WaterTracker.ViewModels
{
    class WaterPageViewModel : BaseViewModel
    {
        public WaterPageViewModel()
        {
            GolMiliLiters = Convert.ToInt32(App.Current.Properties["watergol"]);
            Initialize();
            MessagingCenter.Subscribe<WaterPicker,Drink>(this, "NewDrinkAdd", DrinkAdd);
        }
        public ICommand Add => new Command(PopupedAsync<WaterPicker>);
        public void Initialize()
        {
            try
            {
                var now = DateTime.Now;
                var items = db.GetItems<Drink>().Where(d => d.dateTime.Year == now.Year && d.dateTime.DayOfYear == now.DayOfYear);
                CurrentValue = items.Sum(x => x.ValueInMilliliters);
                Gol = CurrentValue / (GolMiliLiters / 100);
                WaterBalance = $"{CurrentValue}/{GolMiliLiters}";
            }
            catch (Exception EX)
            {
                Debug.WriteLine(EX.Message);
            }
          
        }

        private int CurrentValue { get; set; }
        public int GolMiliLiters { get; set; }

        private int _gol;
        public int Gol
        {
            get => _gol;
            set => Set(ref _gol, value);
        }        

        private string _waterBalance;
        public string WaterBalance
        {
            get => _waterBalance;
            set => Set(ref _waterBalance, value);
        }

        private void DrinkAdd(object sender, Drink drink)
        {
            drink.ValueInMilliliters = Convert.ToInt32(WaterGolService.GetDrinkCoef(drink.Type) * drink.ValueInMilliliters);
            db.Add(drink);
            CurrentValue += drink.ValueInMilliliters;
            Initialize();
        }
    }
}
