using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using WaterTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterPicker : PopupPage
    {
        public WaterPicker()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            string action = await DisplayActionSheet("Select size", "Cancel", null, "200ml", "300ml", "400ml", "500ml", "600ml");
            if (action.Equals("Cancel"))
                return;

            var drink = new Drink
            {
                dateTime = DateTime.Now,
                ValueInMilliliters = int.Parse(action.Replace("ml","")),
                Type = ParseEnum<Drink.Types>((sender as Button).Text)
            };
            MessagingCenter.Send(this, "NewDrinkAdd", drink);
            await PopupNavigation.Instance.PopAsync();
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        private async void OpenInfo(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new WaterCoefDialog());
        }
    }
}