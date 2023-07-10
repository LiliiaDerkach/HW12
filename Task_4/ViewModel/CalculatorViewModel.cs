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

        private List<string> _signsList;

        bool canAddNewElement;
        bool isSingChange = false;
        bool canAddFirstOperand = true;
        bool canDoResult = false;
        bool canSignAdd = true;

        private double _firstOperandNum;
        private double _secondOperandNum;

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
            _signsList = new List<string>();
        }

        public string Formula
        {
            get => _formula;
            set { _formula = value; OnPropertyChanged(nameof(Formula)); }
        }

        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(nameof(Result)); }
        }

        public string CurrentNumber
        {
            get => _currentNumber;

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
            canAddFirstOperand = true;
            isSingChange = false;
            canDoResult = false;
            _signsList = new List<string>();
        }
        public void CreateSing(string par)
        {
            _signOfFormula = par;
            _signsList.Add(_signOfFormula);

            if (_firstOperandStr != null && _signOfFormula != "=" && canSignAdd)
            {
                Formula += _signOfFormula;
                canAddFirstOperand = false;
                canSignAdd = false;
            }

            if (_signsList.Count >= 2)
                isSingChange = true;


            if (_signOfFormula is "=")
            {
                CurrentNumber = Result;
                isSingChange = false;
            }

            if (_secondOperandStr != null)
            {
                canDoResult = true;
                CreateResult();
                CurrentNumber = Result;
            }

            if (isSingChange && _secondOperandStr != null)
            {
                CurrentNumber = Result;
                Formula = null;
                _firstOperandStr = Result;
                Formula += _firstOperandStr;
                Formula += _signOfFormula;
                _secondOperandStr = null;
                canDoResult = false;
            }


        }
        public void CreateFormula(string par)
        {
            if (_signOfFormula == "=") Formula = null;
            _numberFromButton = par;
            canAddNewElement = true;

            if (canAddFirstOperand)
                CreateFirstOperand();


            if (canAddNewElement)
                CreateSecondOperand();

            if (canDoResult)
                CreateResult();
        }

        public void CreateFirstOperand()
        {
            if (_signOfFormula != null && _signOfFormula == "-")
            {
                _firstOperandStr += _signOfFormula;
                _signsList.Remove(_signOfFormula);
                _signOfFormula = null;
            }
            _firstOperandStr += _numberFromButton;
            canAddNewElement = false;
            CurrentNumber = _firstOperandStr;
            canSignAdd = true;
            Formula = _firstOperandStr;

        }

        public void CreateSecondOperand()
        {
            _secondOperandStr += _numberFromButton;
            Formula += _numberFromButton;
            CurrentNumber = _secondOperandStr;
            canSignAdd = true;
        }

        public void CreateResult()
        {
            switch (_signsList[_signsList.Count - 2])
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
