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
        private string _currentNumber;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfFormula;
        private string _numberFromButton;
        bool canAddNewElement;
        bool isSingChange = false;

        private double _firstOperandNum;
        private double _secondOperandNum;
        private int _count;


        public ICommand ShowNumbers { get; set; }
        public ICommand ShowSign { get; set; }
        public ICommand ShowResult { get; set; }
        public ICommand ResetAll { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowNumbers = new RelayCommand<string>(CreateFormula);
            ShowSign = new RelayCommand<string>(CreateSing);
            ShowResult = new RelayCommand(CreateResult);
            ResetAll = new RelayCommand(Reset);
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
            Formula = null;
            Result = null;
            CurrentNumber = null;
            _firstOperandStr = null;
            _secondOperandStr = null;
            _signOfFormula = null;
            _firstOperandNum = 0;
            _secondOperandNum = 0;
            _count = 0;
        }
        public void CreateSing(string par)
        {
            _count++;
            _signOfFormula = par;
            Formula += _signOfFormula;

            if (_count > 2)
                isSingChange = true;


            if (_signOfFormula is "=")
            {
                CurrentNumber = Result;
                isSingChange = false;
            }

            if (isSingChange is true)
            {
                CurrentNumber = Result;
                Formula = null;
                _firstOperandStr = Result;
                Formula += _firstOperandNum;
                Formula += _signOfFormula;
                _secondOperandStr = null;
            }
        }
        public void CreateFormula(string par)
        {
            _numberFromButton = par;
            canAddNewElement = true;

            if (_count <= 2)
                CreateFirstOperand();


            if (_signOfFormula != null && canAddNewElement == true)
                CreateSecondOperand();

            CreateResult();
        }

        public void CreateFirstOperand()
        {
            if (_count == 0)
            {
                _count++;
                _firstOperandStr += _numberFromButton;
                Formula += _numberFromButton;
                canAddNewElement = false;
            }

            if (canAddNewElement == true && _signOfFormula == null)
            {
                _firstOperandStr += _numberFromButton;
                Formula += _numberFromButton;
                canAddNewElement = false;
            }
            CurrentNumber = _firstOperandStr;
        }

        public void CreateSecondOperand()
        {
            if (_secondOperandStr == null)
            {
                _secondOperandStr += _numberFromButton;
                Formula += _numberFromButton;
                canAddNewElement = false;
            }

            if (canAddNewElement == true)
            {
                _secondOperandStr += _numberFromButton;
                Formula += _numberFromButton;
                canAddNewElement = false;
            }
            CurrentNumber = _secondOperandStr;
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
