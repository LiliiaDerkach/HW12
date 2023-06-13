using System;
using MyStopWatch.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyStopWatch.ViewModel
{
    internal class ChangeTimeViewModel : INotifyPropertyChanged
    {
        private MyStopWatchViewModel _myStopWatchViewModel;
        public MyStopWatchViewModel StopWatchViewModel
        {
            get
            {
                return _myStopWatchViewModel;
            }
            set
            {
                _myStopWatchViewModel = value;
                OnPropertyChanged(nameof(MyStopWatchViewModel));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
