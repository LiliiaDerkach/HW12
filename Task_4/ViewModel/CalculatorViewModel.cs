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
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfFormula;
        private string _numberFromButton;
        bool IsAddNewElement;

        private double _firstOperandNum;
        private double _secondOperandNum;
        private int _count;

        public List<string> AllPartsOfFormula = new();


        public ICommand ShowNumbers { get; set; }
        public ICommand ShowSign { get; set; }
        public ICommand ShowResult { get; set; }
        public ICommand ResetAll { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowNumbers = new RelayCommand(CreateFormula);
            ShowSign = new RelayCommand(CreateSing);
            ShowResult = new RelayCommand((parametr => CreateResult()));
            ResetAll = new RelayCommand((parametr => Reset()));
        }
        //secondOpend is firstOperand when click = or sign
        //Add to secondOperand new number 
        // Add new sign
        public string ResetFormula
        {
            get { return _signOfFormula; }
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

        public void Reset()
        {
            ResetFormula = null;
            Formula = null;
            Result = null;
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
            _numberFromButton = par.ToString();
            AllPartsOfFormula.Add(_numberFromButton);
            _signOfFormula = _numberFromButton;
            Formula += _signOfFormula;
        }
        public void CreateFormula(object par)
        {
            _numberFromButton = par.ToString();
            IsAddNewElement = true;
            if (_count > 2 || Result != null)
            {
                _firstOperandStr = Result;
                //CreateSecondOperand();
            }
            
            if (_count <= 2)

            {
                CreateFirstOperand();
                CreateSecondOperand();
            }
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
                IsAddNewElement = false;
            }
            if (IsAddNewElement == true && _signOfFormula == null)
            {
                if (AllPartsOfFormula.Count > 0)
                    _firstOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
                Formula += _numberFromButton;
                IsAddNewElement = false;
            }
        }

        public void CreateSecondOperand()
        {
            if (_signOfFormula != null && IsAddNewElement == true && _secondOperandStr == null)
            {
                AllPartsOfFormula.Add(_numberFromButton);
                _secondOperandStr = _numberFromButton;
                Formula += _numberFromButton;
                IsAddNewElement = false;
            }
            if (IsAddNewElement == true)
            {
                if (AllPartsOfFormula.Count > 0)
                {
                    _secondOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
                    Formula += _numberFromButton;
                    IsAddNewElement = false;
                }
            }
        }

        public bool IsElementTrue(string element)
        {
            if (element != "+" && element != "-" && element != "*" && element != "/")
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
                    Result =  Addition();
                    break;
                case "-":
                    Result =  Subtraction();
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
