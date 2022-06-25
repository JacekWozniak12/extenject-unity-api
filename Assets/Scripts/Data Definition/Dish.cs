using UnityEngine;

[System.Serializable]
public class Dish
{
    public Dish(FoodType type, Sprite image)
    {
        Type = type;
        Image = image;
    }

    public FoodType Type;
    public Sprite Image;
}