using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AsyncMess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task DoWork(TextBox target, int n)
        {
            await Dispatcher.BeginInvoke((Action)(() =>
             {
                 target.Text = "Working...";
             }));

            for (var i = 0; i < n; ++i)
            {
                Thread.Sleep(10);
            }

            await Dispatcher.BeginInvoke((Action)(() =>
            {
                target.Text = n.ToString();
            }));
        }

        private void KickOffCalc()
        {
            var _1 = DoWork(_fib1000, 1000);
            var _2 = DoWork(_fib100, 100);
            var _3 = DoWork(_fib10, 10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Kick it into the background so the button handler doesn't block.
            Task.Run(() => KickOffCalc());
        }
    }
}
