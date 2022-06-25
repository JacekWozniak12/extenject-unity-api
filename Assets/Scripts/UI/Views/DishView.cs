using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public class DishView : View
{
    Dish _dish;

    Label _dishTitle;
    VisualElement _dishImage;
    Button _closeButton;

    public DishView(Dish dish, VisualTreeAsset asset) : base(asset)
    {
        _dish = dish;
        _dishImage = _instance.Q<VisualElement>("Image");
        _dishTitle = _instance.Q<Label>("Title");
        _closeButton = _instance.Q<Button>("Close");

        _dishImage.style.backgroundImage = new StyleBackground(_dish.Image);
        _dishImage.style.unityBackgroundScaleMode = ScaleMode.StretchToFill;

        _dishTitle.text = dish.Type;
    }

    public VisualElement GetElement() => _instance;
    public void AddCloseAction(System.Action closeAction) => _closeButton.clicked += closeAction;

    public class Factory : PlaceholderFactory<Dish, DishView> { };
}