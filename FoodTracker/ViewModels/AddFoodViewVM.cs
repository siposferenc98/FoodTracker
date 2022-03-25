
namespace FoodTracker.ViewModels
{
    internal class AddFoodViewVM : ViewModelBase
    {
        public ObservableCollection<Food> FoodsToDisplay => Foods.CurrentFoods;

        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);
        public ICommand AddFoodCommand => new Command(AddFood);


        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }

        private void AddFood()
        {
            Foods.CurrentFoods.Add(new("testy"));
        }

    }
}
