namespace FoodTracker.State
{
    internal class CurrentViewState
    {
        public static event Action UserControlChanged;
        private static UserControl _userControl = new WelcomeView();
        public static UserControl CurrentUserControl 
        {
            get => _userControl;
            set
            {
                _userControl = value;
                UserControlChanged?.Invoke();
            }
        }
    }
}
