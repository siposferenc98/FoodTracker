
namespace FoodTracker.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
            DataContext = new WelcomeViewVM();
        }
    }
}
