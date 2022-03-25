using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Models
{
    internal class ButtonCE : ButtonBase
    {
        Func<bool> _canExecute;
        public ButtonCE(Action execute, Func<bool> canexecute) : base(execute)
        {
            _canExecute = canexecute;
        }
        public override bool CanExecute(object? parameter)
        {
            return _canExecute();
        }
    }
}
