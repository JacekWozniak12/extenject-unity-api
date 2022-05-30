using UnityEngine;
using System.Linq;

public partial class FoodTypeController
{
    readonly string[] _foodTypesNames = { "biryani", "burger", "butter-chicken", "dessert", "dosa", "idly", "pasta", "pizza", "rice", "samosa" };

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
        // Performs check for closest representation
        string foodType = _foodTypesNames.FirstOrDefault<string>(x => x == name);

        // Performs check for dish that contains parameter
        if (foodType == default)
        {
            foodType = _foodTypesNames.FirstOrDefault<string>(x => x.Contains(name));
        }

        // Performs check for dish that at least contains same first 
        // and second to last letters and have exact same length
        if (foodType == default)
        {
            foodType = _foodTypesNames.FirstOrDefault<string>(
                x => 
                x[0] == name[0] && x.Length == name.Length && 
                x[x.Length - 2] == name[name.Length - 2] 
                );
        }

        // Takes random food
        if (foodType == default)
        {
            return GetRandomFood();
        }

        return new FoodType(foodType);
    }

    private FoodType GetRandomFood() =>
        new FoodType(_foodTypesNames[Random.Range(0, _foodTypesNames.Length)]);
    
}