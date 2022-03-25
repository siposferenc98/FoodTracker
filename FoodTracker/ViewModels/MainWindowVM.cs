
namespace FoodTracker.ViewModels
{
    internal class MainWindowVM : ViewModelBase
    {

        public UserControl CurrentView => CurrentViewState.CurrentUserControl;

        public MainWindowVM()
        {
            CurrentViewState.UserControlChanged += CurrentViewState_UserControlChanged;
        }

        private void CurrentViewState_UserControlChanged()
        {
            RaisePropertyChanged(nameof(CurrentView));
        }

       
    }
}
