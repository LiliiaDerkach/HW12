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
        private string _result;
        public List<string> numericalExample = new List<string>();

        private string _numberFromButton;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfExample;

        private int _firstOperandNum;
        private int _secondOperandNum;
        private string _resultNum;

        public ICommand ShowResult { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowResult = new RelayCommand((parametr => CreateNumericExample(parametr)));
        }

        public void CreateNumericExample(object par)
        {
            _numberFromButton = par.ToString();

            numericalExample.Add(_numberFromButton);
            if(numericalExample.Count >= 3) { 
            _firstOperandStr = numericalExample[0];
            _signOfExample = numericalExample[1];
            _secondOperandStr = numericalExample[2];
                if (numericalExample[2] is "+")
                    _resultNum = Addition();
            }
            
            Result = $"{_firstOperandStr} {_signOfExample} {_secondOperandStr} = {_resultNum}";
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
