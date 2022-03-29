
namespace FoodTracker.ViewModels
{
    internal class TrackerViewVM : ViewModelBase
    {
        private int _sortSelectedIndex;
        public ObservableCollection<Food> FoodsToDisplay => Foods.CurrentFoods;
        public int SortSelectedIndex
        {
            get => _sortSelectedIndex;
            set
            {
                _sortSelectedIndex = value;
                Foods.SortDisplayList(value);
                RaisePropertyChanged(nameof(FoodsToDisplay));
            }
        }
        
        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);

        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }
    }
}
