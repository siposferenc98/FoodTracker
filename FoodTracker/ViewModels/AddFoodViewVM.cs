


namespace FoodTracker.ViewModels
{
    internal class AddFoodViewVM : ViewModelBase
    {
        private string _newFoodIngredients = "";
        public ObservableCollection<Food> FoodsToDisplay => Foods.CurrentFoods;
        public List<string> Ingredients => Foods.CurrentFoods.SelectMany(x => x.Ingredients).Distinct().ToList();
        public Food NewFood { get; set; } = new();

        public string NewFoodIngredients
        {
            get => _newFoodIngredients;
            set
            {
                _newFoodIngredients = value;
                RaisePropertyChanged();
            }
        }

        public string SelectedIngredient
        {
            set
            {
                if (value is null)
                    return;
                NewFoodIngredients += value+" ";
                RaisePropertyChanged(nameof(NewFoodIngredients));
            }
        }

        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);
        public ICommand AddFoodCommand => new CommandCE(AddFood,AddFoodCE);

        private void RefreshAndSetProperties()
        {
            NewFood = new();
            NewFoodIngredients = "";
            RaisePropertyChanged(nameof(NewFood));
            RaisePropertyChanged(nameof(Ingredients));
        }

        private void AddFood()
        {
            List<string> newIngredients = NewFoodIngredients!.TrimEnd().Split(' ').ToList();
            NewFood.Ingredients = newIngredients;
            NewFood.LastMade = DateTime.Now;
            Foods.CurrentFoods.Add(NewFood);
            Foods.FoodsToDisplay.Add(NewFood);
            RefreshAndSetProperties();
        }

        private bool AddFoodCE()
        {
            return NewFood.Name is not null && NewFood.Name.Length > 0 && NewFoodIngredients is not null && NewFoodIngredients.Length > 0 && NewFood.PrepTime is not 0;
        }
        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }

    }
}
