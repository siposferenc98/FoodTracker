
namespace FoodTracker.Models
{
    internal class Food
    {
        private string _imageUrl;
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public DateTime LastMade { get; set; }
        public string ImageUrl 
        {
            get => File.Exists(_imageUrl) ? _imageUrl : @"/FoodTracker;component/Resources/Addimage.png";
            set => _imageUrl = value; 
        }
        public double PrepTime { get; set; }

        public Food(string name, List<string> ingredients, DateTime lastMade, string imageUrl, double prepTime)
        {
            Name = name;
            Ingredients = ingredients;
            LastMade = lastMade;
            ImageUrl = imageUrl;
            PrepTime = prepTime;
        }
    }
}
