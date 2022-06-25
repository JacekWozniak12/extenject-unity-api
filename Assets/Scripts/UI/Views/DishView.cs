using UnityEngine.UIElements;
using Zenject;

public class DishView : View
{
    Dish _dish;

    VisualElement _dishTitle;
    VisualElement _dishImage;
    Button _closeButton;

    public DishView(VisualTreeAsset asset, Dish dish) : base(asset)
    {
        _dish = dish;
        
    }

    public class Factory : PlaceholderFactory<Dish, DishView> {};
}