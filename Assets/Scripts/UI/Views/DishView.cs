using UnityEngine.UIElements;
using Zenject;

public class DishView : View
{
    public DishView(VisualTreeAsset asset) : base(asset)
    {
    }

    public class Factory : PlaceholderFactory<DishView> {};
}