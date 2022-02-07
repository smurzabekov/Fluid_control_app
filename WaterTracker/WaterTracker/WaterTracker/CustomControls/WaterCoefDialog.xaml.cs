using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace WaterTracker.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterCoefDialog : PopupPage
    {
        public WaterCoefDialog()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}