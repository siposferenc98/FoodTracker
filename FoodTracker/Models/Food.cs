
namespace FoodTracker.Models
{
    internal class Food
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public DateTime LastMade { get; set; }
        public string ImageUrl { get; set; }
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
