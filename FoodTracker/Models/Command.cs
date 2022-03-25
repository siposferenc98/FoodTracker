
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
