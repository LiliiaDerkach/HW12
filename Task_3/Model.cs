using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Task_3
{
    public class Model
    {
        public string TimeForTimer { get;set; }
        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        public string StartTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += TickTimer;
            timer.Start();
            stopWatch.Start();
            return TimeForTimer;

        }
        public void TickTimer(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan timeSpan = stopWatch.Elapsed;
                TimeForTimer = String.Format($"{timeSpan.Hours:00} : {timeSpan.Minutes:00} : {timeSpan.Seconds:00} . {timeSpan.Milliseconds/10:00}");
            }
        }
        public void Stop()
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }
        }

        public void Reset()
        {
            stopWatch.Restart();
            stopWatch.Restart();
        }
    }
}
