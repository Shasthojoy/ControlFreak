namespace ControlFreak.ViewModels
{
    using System;
    using ControlFreak.Views;
    using Livet;

    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            this._handleTreeViewModel = new HandleTreeViewModel();
            this._orderViewModel = new OrderViewModel();
        }

        private HandleTreeViewModel _handleTreeViewModel;
        public HandleTreeViewModel HandleTreeViewModel
        {
            set
            {
                if (this._handleTreeViewModel != value && value != null)
                {
                    this._handleTreeViewModel = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._handleTreeViewModel;
            }
        }

        private OrderViewModel _orderViewModel;
        public OrderViewModel OrderViewModel
        {
            set
            {
                if(this._orderViewModel != value && value != null)
                {
                    this._orderViewModel = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._orderViewModel;
            }
        }

        public void OpenOrderWindow(IntPtr targetHandle)
        {
            var window = new OrderWindow() { DataContext = this.OrderViewModel };
            this.OrderViewModel.TargetHandle = targetHandle;
            window.ShowDialog();
        }
    }
}
