namespace ControlFreak.ViewModels
{
    using ControlFreak.Views;
    using ControlFreak.Models;
    using Livet;
    using Livet.Commands;

    public class HandleTreeViewModel : ViewModel
    {
        public HandleTreeViewModel()
        {
            this.InitializeCommand();
            this.UpdateHandles();
        }

        public HandleObject Handles
        {
            set
            {
                if (this._root != value)
                {
                    this._root = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._root;
            }
        }

        private object _selectedItem;
        public object SelectedItem
        {
            set
            {
                if (this._selectedItem != value)
                {
                    this._selectedItem = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._selectedItem;
            }
        }

        public ViewModelCommand OpenMessageWindowCommand { private set; get; }

        private void InitializeCommand()
        {
            this.OpenMessageWindowCommand = new ViewModelCommand(this.ExecuteOpenMessageWindowCommand);
        }

        private void ExecuteOpenMessageWindowCommand()
        {
            if (this.SelectedItem != null)
                App.ViewModelRoot.OpenOrderWindow(((HandleObject)this.SelectedItem).Handle);
        }

        public void UpdateHandles()
        {
            var root = new HandleObject();
            root.Children.Add(HandleManager.GetAllHandleObject());
            this._root = root;
        }

        private HandleObject _root;
    }
}
