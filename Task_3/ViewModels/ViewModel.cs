using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Task_3.ViewModels;

namespace Task_3.ViewModels
{
    class ViewModel
    {
        Model model = null;
        MainWindow view = null;


        public ViewModel(MainWindow view)
        {
            this.model = new Model();
            this.view = view;
            this.view.myStart += new EventHandler(ButtonStartClick);
            this.view.myStop += new EventHandler(ButtonStopClick);
            this.view.myReset += new EventHandler(ButtonResetClick);
        }
        private void ButtonStartClick(object sender, EventArgs e)
        {
            view.Stopwatch.Text = model.StartTimer();

        }
        private void ButtonStopClick(object sender, EventArgs e)
        {
            model.Stop();
        }
        private void ButtonResetClick(object sender, EventArgs e)
        {
            model.Reset();
        }
    }
}
