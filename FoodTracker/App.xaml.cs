using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Foods.ReadFoodsFromJson();
            Foods.FoodsToDisplay = new(Foods.CurrentFoods);
            base.OnStartup(e);
        }
    }
}
