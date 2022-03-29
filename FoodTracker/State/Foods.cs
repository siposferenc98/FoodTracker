
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace FoodTracker.State
{
    internal class Foods
    {
        public static ObservableCollection<Food> CurrentFoods = new();

        public static void SortDisplayList(int index)
        {
            CurrentFoods = index switch
            {
                0 => new(CurrentFoods.OrderByDescending(x => DateTime.Now - x.LastMade)),
                1 => new(CurrentFoods.OrderBy(x => x.PrepTime)),
                2 => new(CurrentFoods.OrderBy(x => x.Ingredients.Count)),
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

        }
    }
}
