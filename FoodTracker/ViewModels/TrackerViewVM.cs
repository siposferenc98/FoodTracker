
namespace FoodTracker.ViewModels
{
    internal class TrackerViewVM : ViewModelBase
    {
        public ObservableCollection<Food> FoodsToDisplay => Foods.CurrentFoods;

        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);

        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }
    }
}
