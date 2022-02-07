using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterPageView : ContentPage
    {
        public WaterPageView()
        {
            InitializeComponent();
            this.BindingContext = new WaterPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            WaterLoader.RunAnimation();
        }
    }
}