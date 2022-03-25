
namespace FoodTracker.State
{
    internal class Foods
    {
        public static ObservableCollection<Food> CurrentFoods = new();

        public static void SaveFoodsToJson()
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true
            };

            var foodsJson = JsonSerializer.Serialize(CurrentFoods,jsonSerializerOptions);
            File.WriteAllText("./foods.json", foodsJson);

        }

        public static void ReadFoodsFromJson()
        {
            string file = "./foods.json";
            if (File.Exists(file))
            {
                CurrentFoods = JsonSerializer.Deserialize<ObservableCollection<Food>>(File.ReadAllText(file)) ?? new();
            }

        }
    }
}
