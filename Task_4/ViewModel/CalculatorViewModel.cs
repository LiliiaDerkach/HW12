using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4.Model;
using Task_4.Core;
using System.Windows.Input;
using System.Windows.Media;

namespace Task_4.ViewModel
{
    public class CalculatorViewModel : NotifyPropertyChanged
    {
        private Calculator _calculator;
        private string _example;
        private string _result;
        public List<string> numericalExample = new List<string>();

        private string _numberFromButton;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfExample;

        private int _firstOperandNum;
        private int _secondOperandNum;
        private string _resultNum;

        public ICommand ShowExample { get; set; }
        public ICommand ShowResult { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowExample = new RelayCommand((parametr => CreateNumericExample(parametr)));
            ShowResult = new RelayCommand((parametr => CreateResult()));
        }

        public void CreateNumericExample(object par)
        {
            _numberFromButton = par.ToString();

            numericalExample.Add(_numberFromButton);
            //for (int i = 0; i > numericalExample.Count; i++)
            //{
            //    Example = numericalExample[i] + numericalExample[i-1];
            //}
            if (numericalExample.Count >= 3)
            {
                _firstOperandStr = numericalExample[0];
                _signOfExample = numericalExample[1];
                _secondOperandStr = numericalExample[2];
            }

            Example = $"{_firstOperandStr} {_signOfExample} {_secondOperandStr}";
        }
        public void CreateResult()
        {
            switch (_signOfExample)
            {
                case "+":
                    Result = "=" + Addition();
                    break;
                case "-":
                    Result = "=" + Subtraction();
                    break;
                case "*":
                    Result = "=" + Multiplication();
                    break;
                case "/":
                    Result = "=" + Division();
                    break;
            }


        }
        public string Example
        {
            get { return _example; }
            set
            {
                _example = value;
                OnPropertyChanged(nameof(Example));
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
        public string Addition()
        {
            _firstOperandNum = Convert.ToInt32(numericalExample[0]);
            _secondOperandNum = Convert.ToInt32(numericalExample[2]);
            _calculator.Result = _firstOperandNum + _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Subtraction()
        {
            _firstOperandNum = Convert.ToInt32(numericalExample[0]);
            _secondOperandNum = Convert.ToInt32(numericalExample[2]);
            _calculator.Result = _firstOperandNum - _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Division()
        {
            _firstOperandNum = Convert.ToInt32(numericalExample[0]);
            _secondOperandNum = Convert.ToInt32(numericalExample[2]);
            _calculator.Result = _firstOperandNum / _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Multiplication()
        {
            _firstOperandNum = Convert.ToInt32(numericalExample[0]);
            _secondOperandNum = Convert.ToInt32(numericalExample[2]);
            _calculator.Result = _firstOperandNum * _secondOperandNum;
            return _calculator.Result.ToString();
        }
    }
}
