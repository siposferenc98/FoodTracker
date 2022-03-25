using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Models
{
    internal class Command : ButtonBase
    {

        public Command(Action execute) : base(execute)
        {
        }

        public override bool CanExecute(object? parameter) => true;
    }
}
