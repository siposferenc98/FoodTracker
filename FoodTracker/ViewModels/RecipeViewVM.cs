using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.ViewModels
{
    internal class RecipeViewVM : ViewModelBase
    {
        public event Action SaveButtonPressed;

        private string? _recipe;
        private string _foodName;
        private List<string> _ingredients;
        private bool _isReadOnly = true;
        public string? Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                RaisePropertyChanged();
            }
        }
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                RaisePropertyChanged();
            }
        }
        public string FoodName
        {
            get => _foodName;
            set
            {
                _foodName = value;
                RaisePropertyChanged();
            }
        }
        public List<string> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                RaisePropertyChanged();
            }
        }



        public ICommand ToggleRecipeEditCommand => new Command(ToggleRecipeEdit);
        public ICommand SaveRecipeCommand => new Command(SaveRecipe);


        public RecipeViewVM(string foodname, List<string> ingredients, string? recipe)
        {
            FoodName = foodname;
            Ingredients = ingredients;
            Recipe = recipe;
        }

        private void SaveRecipe()
        {
            SaveButtonPressed?.Invoke();
        }

        private void ToggleRecipeEdit()
        {
            IsReadOnly = !IsReadOnly;
        }
    }
}
