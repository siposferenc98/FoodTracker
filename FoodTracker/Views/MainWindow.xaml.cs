
namespace FoodTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        protected override void OnClosed(EventArgs e)
        {
            Foods.SaveFoodsToJson();
            base.OnClosed(e);
        }
    }
}
