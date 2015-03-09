namespace ControlFreak
{
    using System.Windows;
    using ControlFreak.Views;
    using ControlFreak.ViewModels;
    using Livet;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel ViewModelRoot { private set; get; }
        internal static string Name { get { return "Control Freak"; } }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherHelper.UIDispatcher = this.Dispatcher;

            ViewModelRoot = new MainViewModel();
            this.MainWindow = new MainWindow() { DataContext = ViewModelRoot };
            this.MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        public static MessageBoxResult ShowErrorMessage(string text)
        {
            return MessageBox.Show(text, Name, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
