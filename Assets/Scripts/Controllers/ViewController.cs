using UnityEngine;
using Zenject;

public class ViewController : Controller
{
    // Factories
    // [Inject] ErrorView.Factory _errorViewFactory;
    // [Inject] DishView.Factory _dishViewFactory;

    // // Containers
    // [Inject] DisplayViewContainer _displayViewContainer;
    // [Inject] InputViewContainer _inputViewContainer;

    public override void Initialize() { }

    public void DisplayDish(FoodType foodType, Sprite sprite)
    {
    //     DishView view = _dishViewFactory.Create();
    //     view.Initialize(foodType, sprite, () => _displayViewContainer.ClearDish(view));
    //     _displayViewContainer.AddDishView(view);
    }

    public void DisplayError(string title, string content)
    {
    //     ErrorView view = _errorViewFactory.Create();
    //     view.Create(title, content);
    //     _inputViewContainer.AddErrorView(view);
    }
}