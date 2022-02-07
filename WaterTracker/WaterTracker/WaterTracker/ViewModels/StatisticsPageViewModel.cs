using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WaterTracker.Models;
using Xamarin.Forms;
using WaterTracker.Views;
using System.Threading.Tasks;
using WaterTracker.CustomControls;

namespace WaterTracker.ViewModels
{
    class StatisticsPageViewModel : BaseViewModel
    {
        public ICommand OpenDetails => new Command<DailyDrinks>(NavigateAsync<DailyDrinksPage>);

        private ObservableCollection<DailyDrinks> _dailyDrinks;
        public ObservableCollection<DailyDrinks> DailyDrinks 
        {
            get => _dailyDrinks;
            set => Set(ref _dailyDrinks, value);
        } 

        public StatisticsPageViewModel()
        {
            DailyDrinks = new ObservableCollection<DailyDrinks>(GetDrinks());
            MessagingCenter.Subscribe<WaterPicker, Drink>(this, "NewDrinkAdd", 
                async (send,obj)=> await ItemHasAdd(send, obj));
        }

        public ICollection<DailyDrinks> GetDrinks()
        {
            var drinks = db.GetItems<Drink>();
            var result = new List<DailyDrinks>();
            foreach (var drink in drinks)
            {
                var dailyDrink = result.FirstOrDefault(
                    x => x.dateTime.DayOfYear == drink.dateTime.DayOfYear 
                    && x.dateTime.Year == drink.dateTime.Year);

                if (dailyDrink is null)
                {
                    dailyDrink = new DailyDrinks { dateTime = drink.dateTime, drinks = new List<Drink>() };
                    result.Add(dailyDrink);
                }
                dailyDrink.drinks.Add(drink);
            }
            return result;
        }

        private static object locker = new object();
        private async Task ItemHasAdd(object sender, Drink drink)
        {
            await Task.Delay(200);
            lock (locker)
            {               
                var newDrinks = GetDrinks();
                DailyDrinks = new ObservableCollection<DailyDrinks>(newDrinks);
            }
        }
    }
}
