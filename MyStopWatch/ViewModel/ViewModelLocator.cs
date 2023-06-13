using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStopWatch.ViewModel
{
    public class ViewModelLocator
    {
        public MyStopWatchViewModel viewModel { get; set; }
        public ViewModelLocator()
        {
            viewModel = new MyStopWatchViewModel();
        }
    }
}
