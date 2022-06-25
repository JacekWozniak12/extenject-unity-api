using UnityEngine;
using Zenject;

public class ViewController : Controller
{
    // Factories
    [Inject] ErrorView.Factory _errorViewFactory;
    [Inject] DishView.Factory _dishViewFactory;
    [Inject] MainUI _mainUI;

    public override void Initialize() { }

    public void DisplayDish(Dish dish)
    {
        DishView view = _dishViewFactory.Create(dish);
    }

    public void DisplayError(string errorMessage)
    {
        ErrorView view = _errorViewFactory.Create(errorMessage);
    }
}