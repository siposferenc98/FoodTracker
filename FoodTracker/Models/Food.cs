

namespace FoodTracker.Models
{
    internal class Food : ViewModelBase
    {
        private string _name = "";
        private string _imageUrl = "";
        private double _prepTime;
        private DateTime _lastMade;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
        public List<string> Ingredients { get; set; } = new();
        public DateTime LastMade 
        {
            get => _lastMade;
            set
            {
                _lastMade = value;
                RaisePropertyChanged();
            }
        }
        public string ImageUrl 
        {
            get => File.Exists(_imageUrl) ? _imageUrl : @"/FoodTracker;component/Resources/Addimage.png";
            set
            {
                _imageUrl = value;
                RaisePropertyChanged();
            }
        }
        public double PrepTime 
        {
            get => _prepTime;
            set
            {
                _prepTime = value;
                RaisePropertyChanged();
            }
        }

        [JsonIgnore]
        public ICommand ChangeImageCommand => new Command(ChangeImage);
        [JsonIgnore]
        public ICommand DeleteThisCommand => new Command(DeleteThis);

        public Food(string name, List<string> ingredients, DateTime lastMade, string imageUrl, double prepTime)
        {
            Name = name;
            Ingredients = ingredients;
            LastMade = lastMade;
            ImageUrl = imageUrl;
            PrepTime = prepTime;
        }

        public Food()
        {

        }

        private void ChangeImage()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageUrl = openFileDialog.FileName;
            }
        }

        private void DeleteThis()
        {
            Foods.CurrentFoods.Remove(this);
        }
    }
}
