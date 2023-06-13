using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Task_3
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

        public event EventHandler myStart = null;
        public event EventHandler myStop = null;
        public event EventHandler myReset = null;
        private void ButtonStartClick(object sender, RoutedEventArgs e)
        {
            myStart.Invoke(sender, e);
        }

        private void ButtonStopClick (object sender, RoutedEventArgs e)
        {
            myStop.Invoke(sender, e);
        }

        private void ButtonResetClick(object sender, RoutedEventArgs e)
        {
            myReset.Invoke(sender, e);
        }
    }
}
