

namespace FoodTracker.Views
{
    /// <summary>
    /// Interaction logic for AddFoodView.xaml
    /// </summary>
    public partial class AddFoodView : UserControl
    {
        public AddFoodView()
        {
            InitializeComponent();
            DataContext = new AddFoodViewVM();
        }
    }
}
