using System;
using System.Collections.Generic;
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //            var task = DoWait();
            //            await task;
            //            Label.Content = "Hey! " + ++count;
//            var result = await DoWait();
//
//            await ExceptionDemo();

            Label.Content = "starting timer";
            await DoTimer(500);
            Label.Content = "Timer ready!";

        }

        private async Task ExceptionDemo()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            Label.Content = "running ...";
            var task = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    //if (token.IsCancellationRequested) return;
                    Thread.Sleep(500);
                    _dispatcher.Invoke(() => { Label.Content += "."; });
                }
            }, token);
            await task;
            Label.Content += $"stopped f:{task.IsFaulted} ca:{task.IsCanceled} com:{task.IsCompleted}";

        }


        private Task<string> DoWait()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "ready!";
            });
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }

        private Task DoTimer(int milleseconds)
        {
            var et = new EventTrigger();
            var tcs = new TaskCompletionSource<object>();
            et.Ready += (sender, args) =>
            {
                tcs.SetResult(null);
                tcs.
            };
            et.Run(milleseconds);
            return tcs.Task;
        }
    }
}