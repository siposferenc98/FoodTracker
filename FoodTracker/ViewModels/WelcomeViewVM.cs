
namespace FoodTracker.ViewModels
{
    internal class WelcomeViewVM : ViewModelBase
    {
        public ICommand ShowFoodUI => new Command(ShowFood);
        public ICommand ShowTrackerUI => new Command(ShowTracker);

        private void ShowFood()
        {
            CurrentViewState.CurrentUserControl = new AddFoodView();
        }
        private void ShowTracker()
        {
            CurrentViewState.CurrentUserControl = new TrackerView();
        }
    }
}
