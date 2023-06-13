using MyStopWatch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStopWatch.ViewModel
{
    public interface IMyStopWatchViewModel
    {
        public List<MyStopWatchModel> GetStopWatches();
        public void Add(MyStopWatchModel stopWatch);
        public void Remove(MyStopWatchModel stopWatch);
        public string TimeForStopWatch();
    }
}
