using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WaterTracker.Services;
using Xamarin.Forms;

namespace WaterTracker.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        private INavigation Navigation => Application.Current.MainPage.Navigation;

        protected NotificationService NotificationService => NotificationService.Current;

        protected IMangaer db => (Application.Current as App).DataBase;

        bool isBusy = false;
        protected bool IsBusy
        {
            get { return isBusy; }
            set { Set(ref isBusy, value); }
        }


        protected bool Set<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        protected void NavigateAsync<T>(object args) where T : Page 
            => Navigation.PushModalAsync((T)Activator.CreateInstance(typeof(T), args));
        protected void PopupedAsync<T>() where T : PopupPage, new() => PopupNavigation.Instance.PushAsync(new T());


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
