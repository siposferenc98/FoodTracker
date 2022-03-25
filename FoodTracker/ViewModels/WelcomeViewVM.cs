using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.ViewModels
{
    internal class WelcomeViewVM : ViewModelBase
    {
        public ICommand ShowFoodUI => new ButtonCE(ShowFood,()=>true);

        private void ShowFood()
        {
            CurrentViewState.CurrentUserControl = new AddFoodView();
        }
    }
}
