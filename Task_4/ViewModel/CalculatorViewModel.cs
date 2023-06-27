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
    public class CalculatorViewModel : BaseViewModel
    {
        private readonly Calculator _calculator;
        private string _formula;
        private string _result;
        private string _reset;
        private string _currentNumber;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfFormula;
        private string _numberFromButton;
        bool isAddNewElement;
        bool isSingChange = false;

        private double _firstOperandNum;
        private double _secondOperandNum;
        private int _count;

        public List<string> AllPartsOfFormula = new();


        public ICommand ShowNumbers { get; set; }
        public ICommand ShowSign { get; set; }
        public ICommand ShowResult { get; set; }
        public ICommand ResetAll { get; set; }
        public ICommand ShowCurrentNumber { get; set; }
        //число введене зараз
        //формула, яка виводиться коли я ввожу знак або дорівнює. Після натиску дорівнює а потім цифри формула починає створюватися заново

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowNumbers = new RelayCommand(CreateFormula);
            ShowSign = new RelayCommand(CreateSing);
            ShowResult = new RelayCommand((parametr => CreateResult()));
            ResetAll = new RelayCommand((parametr => Reset()));
        }

        public string ResetFormula
        {
            get { return _result; }
            set
            {
                _reset = value;
                OnPropertyChanged(nameof(ResetFormula));
            }
        }

        public string Formula
        {
            get { return _formula; }
            set
            {
                _formula = value;
                OnPropertyChanged(nameof(Formula));
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
        public string CurrentNumber
        {
            get
            {
                return _currentNumber;
            }
            set { _currentNumber = value; OnPropertyChanged(nameof(CurrentNumber)); }
        }
        public void Reset()
        {
            ResetFormula = null;
            Formula = null;
            Result = null;
            CurrentNumber = null;
            AllPartsOfFormula = new List<string>();
            _firstOperandStr = null;
            _secondOperandStr = null;
            _signOfFormula = null;
            _firstOperandNum = 0;
            _secondOperandNum = 0;
            _count = 0;
        }
        public void CreateSing(object par)
        {
            _count++;
            _signOfFormula = par.ToString();
            Formula += _signOfFormula;

            if (_count > 2)
            {
                isSingChange = true;
            }
            if (_signOfFormula is "=" || isSingChange is true)
            {
                CurrentNumber = Result;
                isSingChange = false;
            }
        }
        public void CreateFormula(object par)
        {
            if(_signOfFormula is "=")
                Formula = null;

            _numberFromButton = par.ToString();
            CurrentNumber = _numberFromButton;
            isAddNewElement = true;
            if (_count > 2 || Result != null)
            {
                //Formula = null;
                _firstOperandStr = Result;
                //Formula += _firstOperandStr;
                //Formula += _signOfFormula;
                _secondOperandStr = null;
            }

            if (_count <= 2)

            {
                CreateFirstOperand();
            }
            CreateSecondOperand();
            CreateResult();
        }

        public void CreateFirstOperand()
        {
            if (_count == 0)
            {
                _count++;
                AllPartsOfFormula.Add(_numberFromButton);
                _firstOperandStr = _numberFromButton;
                Formula += _numberFromButton;
                isAddNewElement = false;
            }
            if (isAddNewElement == true && _signOfFormula == null)
            {
                if (AllPartsOfFormula.Count > 0)
                    _firstOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
                Formula += _numberFromButton;
                isAddNewElement = false;
            }
        }

        public void CreateSecondOperand()
        {
            if (_signOfFormula != null && isAddNewElement == true && _secondOperandStr == null)
            {
                AllPartsOfFormula.Add(_numberFromButton);
                _secondOperandStr = _numberFromButton;
                Formula += _numberFromButton;
                isAddNewElement = false;
            }
            if (isAddNewElement == true)
            {
                if (AllPartsOfFormula.Count > 0)
                {
                    _secondOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
                    Formula += _numberFromButton;
                    isAddNewElement = false;
                }
            }
        }

        public bool IsElementTrue(string element)
        {
            //if (element != "+" && element != "-" && element != "*" && element != "/")
            if (element is Int32 || element is Double)
                return true;
            else return false;
        }
        public bool IsSignTrue(string sign)
        {
            if (sign == "+" || sign == "-" || sign == "*" || sign == "/")
                return true;
            else return false;
        }

        public void CreateResult()
        {
            switch (_signOfFormula)
            {
                case "+":
                    Result = Addition();
                    break;
                case "-":
                    Result = Subtraction();
                    break;
                case "*":
                    Result = Multiplication();
                    break;
                case "/":
                    Result = Division();
                    break;
            }
        }

        public void OperansToDouble()
        {
            _firstOperandNum = Convert.ToDouble(_firstOperandStr);
            _secondOperandNum = Convert.ToDouble(_secondOperandStr);
        }

        public string Addition()
        {
            OperansToDouble();
            _calculator.Result = _firstOperandNum + _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Subtraction()
        {
            OperansToDouble();
            _calculator.Result = _firstOperandNum - _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Division()
        {
            OperansToDouble();
            _calculator.Result = _firstOperandNum / _secondOperandNum;
            return _calculator.Result.ToString();
        }
        public string Multiplication()
        {
            OperansToDouble();
            _calculator.Result = _firstOperandNum * _secondOperandNum;
            return _calculator.Result.ToString();
        }
    }
}
