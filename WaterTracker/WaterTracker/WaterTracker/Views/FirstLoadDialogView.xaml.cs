using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoadDialogView : ContentPage
    {
        public FirstLoadDialogView()
        {
            InitializeComponent();            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string watergol = null;
            while (watergol is null)
            {
                watergol = await DisplayPromptAsync("Whats your water gol in a day?", "value must be entered in liters",
                initialValue: "2", maxLength: 2, keyboard: Keyboard.Numeric);
            }
            App.Current.Properties.Add(nameof(watergol), watergol);
            await App.Current.SavePropertiesAsync();
            App.Current.MainPage = new MainPage();
        }
    }
}