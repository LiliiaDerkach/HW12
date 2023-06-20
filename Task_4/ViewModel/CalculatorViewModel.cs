using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4.Model;
using Task_4.Core;
using System.Windows.Input;

namespace Task_4.ViewModel
{
    public class CalculatorViewModel : NotifyPropertyChanged
    {
        private Calculator _calculator;
        private string _result;
        public List<string> numericalExample = new List<string>();
        public ICommand ShowResult { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowResult = new RelayCommand((parametr => Result = parametr.ToString()));
            numericalExample.Add(Result);

        }
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public string Addition()
        {
            double a = 1;
            double b = 2;
            _calculator.Result = a + b;
            return _calculator.Result.ToString();
        }
        public void Subtraction()
        {

        }
        public void Division()
        {

        }
        public void Multiplication()
        {

        }
    }
}
