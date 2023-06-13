using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.ViewModels
{
    public class ViewModelTick : ViewModelBase
    {
        private Model _tick;

        public Model Tick
        {
            get { return _tick; }
            set
            {
                _tick = value;
                OnPropertyChanged(nameof(Tick));
            }
        }
    }
}
