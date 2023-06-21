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
        private string _reset;
        public List<string> numericalExample = new List<string>();

        private string _numberFromButton;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfExample;

        private int _firstOperandNum;
        private int _secondOperandNum;

        public ICommand ShowExample { get; set; }
        public ICommand ShowResult { get; set; }
        public ICommand ResetAll { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowExample = new RelayCommand((parametr => CreateNumericExample(parametr)));
            ShowResult = new RelayCommand((parametr => CreateResult()));
            ResetAll = new RelayCommand((paramr => Reset()));
        }

        public void Reset()
        {
            ResetExample = null;
            Example = null;
            Result = null;
            numericalExample = new List<string>();
            _firstOperandStr = null;
            _secondOperandStr = null;
            _signOfExample = null;
            _firstOperandNum = 0;
            _secondOperandNum = 0;
        }
        public void CreateNumericExample(object par)
        {
            _numberFromButton = par.ToString();
            numericalExample.Add(_numberFromButton);
            Example += _numberFromButton;

        }
        public void CreateNumbers()
        {
            for (int i = 0; i < numericalExample.Count; i++)
            {
                bool isContinue = true;

                if (_signOfExample != null)
                {
                    if (numericalExample[i] != "+" || numericalExample[i] != "-" || numericalExample[i] != "*" || numericalExample[i] != "/")
                    { _secondOperandStr += numericalExample[i]; }
                }
                if (numericalExample[i] == "+" || numericalExample[i] == "-" || numericalExample[i] == "*" || numericalExample[i] == "/")
                {
                    _signOfExample = numericalExample[i];
                }
                while (isContinue == true && _signOfExample == null)
                {
                    if (numericalExample[i] != "+" || numericalExample[i] != "-" || numericalExample[i] != "*" || numericalExample[i] != "/")
                    {
                        _firstOperandStr += numericalExample[i];
                        isContinue = false;
                    }
                }

            }
        }
        public void CreateResult()
        {
            CreateNumbers();
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

        public string ResetExample
        {
            get { return _signOfExample; }
            set
            {
                _reset = value;
                OnPropertyChanged(nameof(Reset));
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
            _firstOperandNum = Convert.ToInt32(_firstOperandStr);
            _secondOperandNum = Convert.ToInt32(_secondOperandStr);
            _calculator.Result = _firstOperandNum + _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Subtraction()
        {
            _firstOperandNum = Convert.ToInt32(_firstOperandStr);
            _secondOperandNum = Convert.ToInt32(_secondOperandStr);
            _calculator.Result = _firstOperandNum - _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Division()
        {
            _firstOperandNum = Convert.ToInt32(_firstOperandStr);
            _secondOperandNum = Convert.ToInt32(_secondOperandStr);
            _calculator.Result = _firstOperandNum / _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Multiplication()
        {
            _firstOperandNum = Convert.ToInt32(_firstOperandStr);
            _secondOperandNum = Convert.ToInt32(_secondOperandStr);
            _calculator.Result = _firstOperandNum * _secondOperandNum;
            return _calculator.Result.ToString();
        }
    }
}
