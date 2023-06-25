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
        private Calculator _calculator;
        private string _formula;
        private string _result;
        private string _reset;
        private string _firstOperandStr;
        private string _secondOperandStr;
        private string _signOfFormula;

        private double _firstOperandNum;
        private double _secondOperandNum;
        private int _count;

        public List<string> AllPartsOfFormula = new List<string>();


        public ICommand ShowFormula { get; set; }
        public ICommand ShowResult { get; set; }
        public ICommand ResetAll { get; set; }

        public CalculatorViewModel()
        {
            _calculator = new Calculator();
            ShowFormula = new RelayCommand(CreateFormula);
            ShowResult = new RelayCommand((parametr => CreateResult()));
            ResetAll = new RelayCommand((parametr => Reset()));
        }

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
        }

        public void CreateFormula(object par)
        {
            string _numberFromButton = par.ToString();
            bool IsAddNewElement = true;
            if (IsAddNewElement == true && _count == 0)
            {
                _count++;
                AllPartsOfFormula.Add(_numberFromButton);
                IsAddNewElement = false;
            }
            if (IsElementTrue(_numberFromButton) && IsAddNewElement == true)
            {
                //_firstOperandStr = ...
                if (AllPartsOfFormula.Count > 0)
                    _firstOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
                IsAddNewElement = false;
            }
            if (IsSignTrue(_numberFromButton))
            {
                //_signOfFormula = ...
                AllPartsOfFormula.Add(_numberFromButton);
                _signOfFormula = _numberFromButton;
                IsAddNewElement = true;
            }
            if (_signOfFormula != null && IsAddNewElement == true)
            {
                AllPartsOfFormula.Add(_numberFromButton);
            }
            if (IsElementTrue(_numberFromButton) && IsAddNewElement == true)
            {
                //_secondOperandStr = ...
                if (AllPartsOfFormula.Count > 0)
                    _secondOperandStr = AllPartsOfFormula[AllPartsOfFormula.Count - 1] += _numberFromButton;
            }


            //AllPartsOfFormula.Add(_numberFromButton);
            Formula += _numberFromButton;
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

        //public void CreatePartsOfFormula()
        //{
        //    for (int i = 0; i < AllPartsOfFormula.Count; i++)
        //    {
        //        bool isContinue = true;
        //        string elementOfMass = AllPartsOfFormula[i];

        //        if (_signOfFormula != null)
        //        {
        //            if (IsElementTrue(elementOfMass))
        //            {
        //                _secondOperandStr += AllPartsOfFormula[i];
        //            }
        //        }

        //        if (IsSignTrue(elementOfMass))
        //        {
        //            _signOfFormula = AllPartsOfFormula[i];
        //        }

        //        while (isContinue == true && _signOfFormula == null)
        //        {
        //            if (IsElementTrue(elementOfMass))
        //            {
        //                _firstOperandStr += AllPartsOfFormula[i];
        //                isContinue = false;
        //            }
        //        }
                //if (_signOfFormula != null && IsSignTrue(elementOfMass))
                //{
                //   _firstOperandNum = _calculator.Result;
                //   _secondOperandStr =
                //}
        //    }
        //}

        public void CreateResult()
        {
            //CreatePartsOfFormula();
            switch (_signOfFormula)
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
