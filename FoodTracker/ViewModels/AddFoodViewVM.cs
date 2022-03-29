


namespace FoodTracker.ViewModels
{
    internal class AddFoodViewVM : ViewModelBase
    {
        private string? _newFoodName;
        private string _newFoodIngredients = "";
        private string _newFoodImgUrl = @"/FoodTracker;component/Resources/Addimage.png";
        private double _newFoodPrepTime;
        public ObservableCollection<Food> FoodsToDisplay => Foods.CurrentFoods;
        public List<string> Ingredients => Foods.CurrentFoods.SelectMany(x => x.Ingredients).Distinct().ToList();

        public string? NewFoodName 
        {
            get => _newFoodName; 
            set
            {
                _newFoodName = value;
                RaisePropertyChanged();
            }
        }
        public string NewFoodIngredients
        {
            get => _newFoodIngredients;
            set
            {
                _newFoodIngredients = value;
                RaisePropertyChanged();
            }
        }

        public string NewFoodImgUrl
        {
            get => _newFoodImgUrl;
            set
            {
                if (value is null)
                    return;
                _newFoodImgUrl = value;
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

        public double NewFoodPrepTime
        {
            get => _newFoodPrepTime;
            set
            {
                _newFoodPrepTime = value;
                RaisePropertyChanged();
            }
        }


        public ICommand ChangeImageCommand => new Command(ChangeImage);
        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);
        public ICommand AddFoodCommand => new CommandCE(AddFood,AddFoodCE);

        public AddFoodViewVM()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            NewFoodImgUrl = @"/FoodTracker;component/Resources/Addimage.png";
            NewFoodIngredients = "";
            NewFoodName = null;
            NewFoodPrepTime = 0;
        }

        private void ChangeImage()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            if (openFileDialog.ShowDialog() == true)
            {
                NewFoodImgUrl = openFileDialog.FileName;
            }
        }

        private void AddFood()
        {
            List<string> newIngredients = NewFoodIngredients!.TrimEnd().Split(' ').ToList();
            Food newFood = new(NewFoodName!, newIngredients, DateTime.Now, NewFoodImgUrl, NewFoodPrepTime);
            Foods.CurrentFoods.Add(newFood);

            SetDefaultValues();
            RaisePropertyChanged(nameof(Ingredients));
        }

        private bool AddFoodCE()
        {
            return NewFoodName is not null && NewFoodName.Length > 0 && NewFoodIngredients is not null && NewFoodIngredients.Length > 0 && NewFoodPrepTime is not 0;
        }
        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }

    }
}
