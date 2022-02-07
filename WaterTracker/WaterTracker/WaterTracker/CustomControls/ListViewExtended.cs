using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WaterTracker.CustomControls
{
    public class ListViewExtended : ListView
    {
        public event EventHandler<ListViewScrolledEventArgs> OnScroll;

        public static readonly BindableProperty ItemClickCommandProperty =
            BindableProperty.Create(nameof(ItemClickCommand), typeof(ICommand),
                typeof(ListViewExtended), default(ICommand));

        public ICommand ItemClickCommand
        {
            get => (ICommand)this.GetValue(ItemClickCommandProperty);
            set => this.SetValue(ItemClickCommandProperty, value);
        }

        public ListViewExtended()
        {
            this.ItemTapped += this.OnItemTapped;
        }

        public ListViewExtended(ListViewCachingStrategy listViewCachingStrategy) : base(listViewCachingStrategy)
        {
            this.ItemTapped += this.OnItemTapped;
        }

        public void RaiseOnScrollEvent(double scrollY)
        {
            OnScroll?.Invoke(this, new ListViewScrolledEventArgs() { ScrollY = scrollY });
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
            }
        }
        public class ListViewScrolledEventArgs : EventArgs
        {
            public double ScrollY { get; set; }
        }
    }
}
