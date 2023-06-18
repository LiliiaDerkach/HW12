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
        private string _number;
        public CalculatorViewModel()
        {
            _calculator = new Calculator();
        }
        public ICommand ShowResult
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Result = Addition();
                }
                );
            }
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
        //public ICommand ShowNumber
        //{
        //    get
        //    {
        //        return new ActionCommand(() =>
        //        {
        //            Number = "1";
        //        }
        //        );
        //    }
        //}
        //public string Number
        //{
        //    get { return _number; }
        //    set
        //    {
        //        _number = value;
        //        OnPropertyChanged(nameof(Number));
        //    }
        //}
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
