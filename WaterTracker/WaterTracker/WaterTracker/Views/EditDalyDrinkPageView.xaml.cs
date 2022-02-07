using WaterTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDalyDrinkPageView : ContentPage
    {
        public EditDalyDrinkPageView()
        {
            InitializeComponent();
            this.BindingContext = new EditDalyDrinkPageViewModel(false);
        }

        public EditDalyDrinkPageView(bool isFirstLoad)
        {
            InitializeComponent();
            this.BindingContext = new EditDalyDrinkPageViewModel(isFirstLoad);
        }
    }
}