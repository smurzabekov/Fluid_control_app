using WaterTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPageView : ContentPage
    {
        public SettingsPageView()
        {
            InitializeComponent();
            this.BindingContext = new SettingsPageViewModel();
        }
        //public SettingsPageView()
        //{
        //    InitializeComponent();
        //    BindingContext = this;
        //    watergol = App.Current.Properties[nameof(watergol)] as string;
        //    lable.Text = $"My current water day gol is {watergol} liters"; ;
        //}

        //private string watergol = string.Empty;
        //public Command ChangeWaterGolCommand => new Command(async()=> await ChangeWaterGol());
        //protected async Task ChangeWaterGol()
        //{
        //    string newWaterGol = await DisplayPromptAsync("Whats your water gol in a day?", "value must be entered in liters",
        //        initialValue: watergol, maxLength: 2, keyboard: Keyboard.Numeric);
        //    if(newWaterGol is null){
        //        return;
        //    }
        //    App.Current.Properties[nameof(watergol)] = newWaterGol;
        //    await App.Current.SavePropertiesAsync();
        //    App.Current.MainPage = new MainPage();
        //}
    }
}