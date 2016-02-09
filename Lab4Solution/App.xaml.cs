using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace Lab4Solution
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var message = e.Exception?.Message;
            MessageBox.Show(message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
            //navigate to main menu
            File.AppendAllLines("log.txt", new[]
            {
                message, e.Exception?.StackTrace
            });
            EventLog.WriteEntry("DEMO", message);
        }
    }
}