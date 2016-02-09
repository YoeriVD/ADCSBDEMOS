using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Lab4Solution
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dispatcher _dispatcher;
        private CancellationTokenSource _cts;

        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
            _dispatcher = Dispatcher;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //            var task = DoWait();
            //            await task;
            //            Label.Content = "Hey! " + ++count;
            _cts = ExceptionDemo();
        }

        private CancellationTokenSource ExceptionDemo()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            Label.Content = "running ...";
            var t = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    //if (token.IsCancellationRequested) return;
                    Thread.Sleep(500);
                    _dispatcher.Invoke(() => { Label.Content += "."; });
                }
            }, token)
            .ContinueWith(task =>
            {
                _dispatcher.Invoke(() =>
                {
                    Label.Content += $"stopped f:{task.IsFaulted} ca:{task.IsCanceled} com:{task.IsCompleted}";
                });
            });
            return cts;
        }


        private Task DoWait()
        {
            return Task.Run(() => { Thread.Sleep(1000); });
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
            throw new Exception("oepsie!");
        }
    }
}