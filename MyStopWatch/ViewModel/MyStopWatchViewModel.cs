using MyStopWatch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyStopWatch.ViewModel
{
    public class MyStopWatchViewModel : IMyStopWatchViewModel
    {
        public readonly List<MyStopWatchModel> stwModels;
        private readonly MyStopWatchModel stW;
        //public ViewModelLocator ViewLocator { get; set; }

        public MyStopWatchViewModel()
        {
            stwModels = new List<MyStopWatchModel>();
        }

        public List<MyStopWatchModel> GetStopWatches()
        {
            return stwModels;
        }
        public void Add(MyStopWatchModel stopWatch)
        {
            stwModels.Add(stopWatch);
        }

        public void Remove(MyStopWatchModel stopWatch)
        {
            stwModels.Remove(stopWatch);
        }

        public string TimeForStopWatch()
        {
            DateTime time = DateTime.Now;
            stW.Time = $"{time.Hour}:{time.Minute}:{time.Second}";
            return stW.Time;
        }
    }
}
