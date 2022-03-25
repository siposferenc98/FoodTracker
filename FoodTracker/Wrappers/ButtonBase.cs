using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodTracker.Wrappers
{
    internal abstract class ButtonBase : ICommand
    {
        Action _execute;
        public ButtonBase(Action execute)
        {
            _execute = execute;
        }
        public abstract bool CanExecute(object? parameter);

        public void Execute(object? parameter)
        {
            _execute?.Invoke();
        }
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove 
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
