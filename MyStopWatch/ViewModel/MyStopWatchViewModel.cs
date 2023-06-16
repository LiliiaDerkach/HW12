using MyStopWatch.Core;
using MyStopWatch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyStopWatch.ViewModel
{
    public class MyStopWatchViewModel : INotifyPropertyChanged
    {
        private readonly MyStopWatchModel _stW;
        private readonly DispatcherTimer _timer;
        private string _currentTime;
        private int _seconds = 0;
        private int _minutes = 0;
        private int _hours = 0;

        public ActionCommand StartCommand { get; set; }

        public MyStopWatchViewModel()
        {
            _stW = new MyStopWatchModel();
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            //_timer.Start();
        }
        public ICommand StartStopWatch
        {
            get
            {
                return new ActionCommand(() =>
                {
                    _timer.Start();
                });

            }
        }
        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        //private void Timer()
        //{

        //}

        private void TimerTick(object? sender, EventArgs e)
        {
            _seconds++;
            if (_seconds == 60)
            {
                _seconds = 0;
                _minutes++;
            }
            if (_minutes == 60)
            {
                _seconds = 0;
                _minutes = 0;
                _hours++;
            }

            _stW.Time = string.Format("{0:d2} : {1:d2} : {2:d2}", _hours, _minutes, _seconds);
            CurrentTime = _stW.Time;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
