using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.ViewModels
{
    internal class AddFoodViewVM : ViewModelBase
    {
        public ObservableCollection<Food> FoodsToDisplay { get; set; } = Foods.CurrentFoods;

        public ICommand ReturnToMainWindowCommand => new Command(ReturnToMW);


        private void ReturnToMW()
        {
            CurrentViewState.CurrentUserControl = new WelcomeView();
        }
    }
}
