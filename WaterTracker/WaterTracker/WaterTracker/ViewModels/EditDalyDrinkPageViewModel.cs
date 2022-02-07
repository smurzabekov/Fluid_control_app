using System;
using System.Windows.Input;
using WaterTracker.Models;
using WaterTracker.Services;
using Xamarin.Forms;

namespace WaterTracker.ViewModels
{
    class EditDalyDrinkPageViewModel : BaseViewModel
    {
        private readonly bool isFirstLoad;
        public ICommand SaveSettingCommand => new Command(SaveSettings, ()=> CanExecute);

        private bool _sex;
        public bool Sex 
        {
            get => _sex;
            set => Set(ref _sex, value);
        }


        private bool _isSportsman;
        public bool IsSportsman
        {
            get => _isSportsman;
            set => Set(ref _isSportsman, value);
        }        
        public EditDalyDrinkPageViewModel(bool isFirstLoad)
        {
            this.isFirstLoad = isFirstLoad;
            if (!isFirstLoad)
            {
                var settings = db.GetItem<DalyDrinksSettings>(1);
                this.Weight = settings.Weight;
                this.IsSportsman = settings.IsSportsman;
                this.Sex = settings.Sex;
            }
        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set => Set(ref _weight, value);
        }

        private async void SaveSettings()
        {
            CanExecute = false;
            var settings = new DalyDrinksSettings
            {
                Id = 1,
                Sex = this.Sex,
                Weight = this.Weight,
                IsSportsman = this.IsSportsman
            };
            var watergol = WaterGolService.GetGol(isSportsmen: _isSportsman, isWomen: _sex, weight: _weight);

            if (isFirstLoad)
            {
                db.Add(settings);
                AddUserSetttings();
                App.Current.Properties.Add(nameof(watergol), watergol);
            }
            else
            {
                App.Current.Properties[nameof(watergol)] = watergol;
                db.Edit(settings);
            }                

            //Reload app          
            await App.Current.SavePropertiesAsync();
            Device.BeginInvokeOnMainThread(Reload);            
        }

        private void Reload()
        {
            App.Current.MainPage = new MainPage();
        }
        private bool CanExecute { get; set; } = true;
        private void AddUserSetttings()
        {            
            var settings = new UserSettings
            {
                Id = 1,
                DateFrom = TimeSpan.FromHours(10),
                DateTo = TimeSpan.FromHours(21),
                Every = 2,
                NotificationEnable = false,
            };
            db.Add(settings);
        }
        
    }
}
