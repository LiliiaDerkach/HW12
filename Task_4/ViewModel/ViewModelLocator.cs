using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4.ViewModel
{
    public class ViewModelLocator
    {
        public CalculatorViewModel ViewModel { get; set;}
        public ViewModelLocator()
        {
            ViewModel = new CalculatorViewModel();
        }
    }
}
