
namespace FoodTracker.Models
{
    internal class Food
    {
        public string Name { get; init; }
        public List<string> Ingredients { get; set; }

        public Food(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}
