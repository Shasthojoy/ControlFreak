namespace ControlFreak.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using ControlFreak.Models;
    using ControlFreak.Models.WindowMessages;
    using Livet;
    using Livet.Commands;

    public class OrderViewModel : ViewModel
    {
        public OrderViewModel()
        {
            this._lParam = string.Empty;
            this._wParam = string.Empty;
            this._result = string.Empty;

            this.InitializeMessages();
            this.InitializeCommands();
        }

        public IntPtr TargetHandle { set; get; }

        private string _wParam;
        public string WParam
        {
            set
            {
                if (this._wParam != value)
                {
                    this._wParam = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._wParam;
            }
        }

        public string WParamFormat
        {
            get
            {
                return this.SelectedMessage != null ? this.SelectedMessage.WParamFormat : string.Empty;
            }
        }

        private string _lParam;
        public string LParam
        {
            set
            {
                if (this._lParam != value)
                {
                    this._lParam = value;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._lParam;
            }
        }

        public string LParamFormat
        {
            get
            {
                return this.SelectedMessage != null ? this.SelectedMessage.LParamFormat : string.Empty;
            }
        }

        public List<WindowMessage> Messages { private set; get; }

        private object _selectedItem;
        public object SelectedItem
        {
            set
            {
                if (this._selectedItem != value)
                {
                    this._selectedItem = value;
                    this.RaisePropertyChanged();
                    this.RaisePropertyChanged("WParamFormat");
                    this.RaisePropertyChanged("LParamFormat");
                    this.WParam = string.Empty;
                    this.LParam = string.Empty;
                    this.Result = string.Empty;
                    this.MessageSendCommand.RaiseCanExecuteChanged();
                }
            }
            get
            {
                return this._selectedItem;
            }
        }

        private string _result;
        public string Result
        {
            set
            {
                if (this._result != value)
                {
                    this._result = value ?? string.Empty;
                    this.RaisePropertyChanged();
                }
            }
            get
            {
                return this._result;
            }
        }

        public WindowMessage SelectedMessage
        {
            get
            {
                return (WindowMessage)this._selectedItem;
            }
        }

        public ViewModelCommand MessageSendCommand { private set; get; }

        private void InitializeMessages()
        {
            this.Messages = new List<WindowMessage>(4);

            this.Messages.Add(new ENABLE());
            this.Messages.Add(new GETTEXT_AUTO());
            this.Messages.Add(new GETTEXT());
            this.Messages.Add(new GETTEXTLENGTH());
            this.Messages.Add(new MOVE());
            this.Messages.Add(new SETTEXT());
        }

        private void InitializeCommands()
        {
            this.MessageSendCommand = new ViewModelCommand(this.ExecuteMessageSendCommand, this.CanExecuteMessageSendCommand);
        }

        private void ExecuteMessageSendCommand()
        {
            var result = this.SelectedMessage.SendMessage(this.TargetHandle, this.WParam, this.LParam);
            this.Result = result.Success ? result.Value : result.Exception.Message;
        }

        private bool CanExecuteMessageSendCommand()
        {
            return this.SelectedMessage != null;
        }
    }
}
