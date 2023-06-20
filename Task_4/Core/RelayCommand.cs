using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task_4.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public readonly Action <object> _action;
        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return _action != null;
        }

        public void Execute(object? parameter)
        {
            _action.Invoke(parameter);
        }

        protected void OnCanExecuteChanged()
    => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
