using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WaterTracker.Models;
using Xamarin.Forms;

namespace WaterTracker.ViewModels
{
    class SettingsPageViewModel : BaseViewModel
    {
        public ICommand SaveSettingCommand => new Command(AddNotifications);
        public SettingsPageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            var settings = this.db.GetItems<UserSettings>().LastOrDefault();
            DateFrom = settings.DateFrom;
            DateTo = settings.DateTo;
            Every = settings.Every.ToString();
            NotificationEnable = settings.NotificationEnable;
        }

        private TimeSpan _dateFrom;
        public TimeSpan DateFrom
        {
            get => _dateFrom;
            set => Set(ref _dateFrom, value);
        }

        private TimeSpan _dateTo;
        public TimeSpan DateTo
        {
            get => _dateTo;
            set => Set(ref _dateTo, value);
        }

        private string _every;
        public string Every
        {
            get => _every;
            set => Set(ref _every, value);
        }

        private bool _notificationEnable;
        public bool NotificationEnable
        {
            get => _notificationEnable;
            set => Set(ref _notificationEnable, value);             
        }

        private async void AddNotifications()
        {
            var settings = new UserSettings
            {
                Id = 1,
                DateFrom = DateFrom,
                DateTo = DateTo,
                Every = int.Parse(Every),
                NotificationEnable = NotificationEnable
            };
            db.Edit(settings);

            await UpdateNotifications(_notificationEnable);
        }

        private async Task UpdateNotifications(bool isEnable)
        {          
            if (isEnable)
            {
                var now = DateTime.Now;
                var date = new DateTime(now.Year, now.Month, now.Day, DateFrom.Hours, 0, 0);
                var count = DateTo.Hours - DateFrom.Hours;
                if (count < 0)
                    count = 0;
                await NotificationService.SetNotificationsAsync(date, DateTo, count/int.Parse(_every));
            }               
            else
                await NotificationService.CancelAllCurrentAsync();
        }
    }
}
