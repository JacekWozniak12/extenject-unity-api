using UnityEngine;
using System.Linq;

public class FoodTypeController : Controller
{
    public override void Initialize(){}

    public static readonly string[] FoodTypesNames = {
        "biryani", "burger", "butter-chicken",
        "dessert", "dosa", "idly", "pasta",
        "pizza", "rice", "samosa"
        };

    /// <summary>
    /// Returns food type that is available in API, otherwise returns random food type.
    /// Performs .ToLower() and .Trim() on passed parameter
    /// </summary>
    public FoodType GetFoodType(string name)
    {
        name = name.ToLower();
        name = name.Trim();

        return GetClosestFoodTypeAvailable(name);
    }

    private FoodType GetClosestFoodTypeAvailable(string name)
    {
        if (name.Length == 0) return GetRandomFood();

        // Performs check for closest representation
        string foodType = FoodTypesNames.FirstOrDefault<string>(x => x == name);

        // Performs check for dish that contains parameter
        if (foodType == default)
            foodType = FoodTypesNames.FirstOrDefault<string>(x => x.Contains(name));

        // Naive check solution
        string temp = name;
        while (foodType == default && temp.Length > 0)
        {
            temp = temp.Substring(0, temp.Length - 1);
            foodType = FoodTypesNames.FirstOrDefault<string>(x => x.Contains(temp));
        }

        // Takes random food
        if (foodType == default) return GetRandomFood();

        return new FoodType(foodType);
    }

    private FoodType GetRandomFood() =>
        new FoodType(FoodTypesNames[Random.Range(0, FoodTypesNames.Length)]);

}