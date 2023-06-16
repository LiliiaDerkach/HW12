﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyStopWatch.Core
{
    public class ActionCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action _action;
        public ActionCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return _action!= null;
        }

        public void Execute(object? parameter)
        {
            _action.Invoke();
        }
    }
}
