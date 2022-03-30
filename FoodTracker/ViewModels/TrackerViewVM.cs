
namespace FoodTracker.ViewModels
{
    internal class TrackerViewVM : ViewModelBase
    {
        private int _sortSelectedIndex;
        private string _searchText = "";
        public ObservableCollection<Food> FoodsToDisplay => Foods.FoodsToDisplay;
        public int SortSelectedIndex
        {
            get => _sortSelectedIndex;
            set
            {
                _sortSelectedIndex = value;
                Foods.SortDisplayList(value,_searchText);
                RaisePropertyChanged(nameof(FoodsToDisplay));
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                Foods.SortDisplayList(_sortSelectedIndex,value);
                RaisePropertyChanged(nameof(FoodsToDisplay));
            }
        }

        public TrackerViewVM()
        {
            Foods.SortDisplayList(0);
        }
        
        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);

        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }
    }
}
