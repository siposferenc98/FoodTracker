
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace FoodTracker.State
{
    internal class Foods
    {
        public static ObservableCollection<Food> CurrentFoods = new();
        public static ObservableCollection<Food> FoodsToDisplay;

        public static void SortDisplayList(int index, string startsWith = "")
        {
            StringComparison c = StringComparison.CurrentCultureIgnoreCase;
            FoodsToDisplay = new(CurrentFoods.Where(x => x.Name.StartsWith(startsWith, c) || x.Ingredients.Any(i => i.StartsWith(startsWith, c))));

            FoodsToDisplay = index switch
            {
                0 => new(FoodsToDisplay.OrderByDescending(x => DateTime.Now - x.LastMade)),
                1 => new(FoodsToDisplay.OrderBy(x => x.PrepTime)),
                2 => new(FoodsToDisplay.OrderBy(x => x.Ingredients.Count)),
                _ => new(CurrentFoods)
            };
        }

        public static void SaveFoodsToJson()
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            var foodsJson = JsonSerializer.Serialize(CurrentFoods,jsonSerializerOptions);
            File.WriteAllText("./foods.json", foodsJson,Encoding.UTF8);

        }

        public static void ReadFoodsFromJson()
        {
            string file = "./foods.json";
            if (File.Exists(file))
            {
                CurrentFoods = JsonSerializer.Deserialize<ObservableCollection<Food>>(File.ReadAllText(file,Encoding.UTF8)) ?? new();
            }
            FoodsToDisplay = new(CurrentFoods);
        }
    }
}
