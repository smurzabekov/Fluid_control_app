using Plugin.LocalNotification;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WaterTracker.Services
{
    class NotificationService
    {

        #region Singelton

        private static NotificationService _instnce;
        public static NotificationService Current => _instnce ?? (_instnce = new NotificationService());

        #endregion

        public void SetNotification(DateTime dateTime,int id = 100)
        {
            var request = new NotificationRequest
            {
                NotificationId = id,
                Title = "Water tracker",
                Description = $"Its time to drink ",
                NotifyTime = dateTime,
                Repeats = NotificationRepeat.Daily,
                Android = { IconName = "my_icon" },
            };
            NotificationCenter.Current.Show(request);
        }

        public void SetNotification(DateTime dateTime, TimeSpan delay, int id = 100)
        {
            SetNotification(dateTime.AddSeconds(delay.TotalSeconds), id);
        }

        public void SetNotifications(DateTime dateTime, TimeSpan delay,int count)
        {

            while (count != 0)
            {
                SetNotification(dateTime.AddSeconds(delay.TotalSeconds * count), count);
                count--;
            }
        }

        public void CancelAllCurrent()
        {
            Device.BeginInvokeOnMainThread(NotificationCenter.Current.CancelAll);
        }

        public async Task CancelAllCurrentAsync()
        {
            await Task.Factory.StartNew(CancelAllCurrent);
        }

        public async Task SetNotificationsAsync(DateTime dateTime, TimeSpan delay, int count)
        {
            await Task.Factory.StartNew(() => this.SetNotifications(dateTime,delay,count));
        }
    }
}
