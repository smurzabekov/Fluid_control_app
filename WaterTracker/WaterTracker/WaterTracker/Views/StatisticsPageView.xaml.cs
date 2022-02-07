using WaterTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPageView : ContentPage
    {
        public StatisticsPageView()
        {
            InitializeComponent();
            this.BindingContext = new StatisticsPageViewModel();
        }
    }
}