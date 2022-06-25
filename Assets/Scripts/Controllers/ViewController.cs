using UnityEngine;
using Zenject;

public class ViewController : Controller
{
    // Factories
    [Inject] private readonly ErrorView.Factory _errorViewFactory;
    [Inject] private readonly DishView.Factory _dishViewFactory;
    [Inject] private readonly RequestView.Factory _requestViewFactory;

    [Inject] private MainUI _mainUI;

    public override void Initialize()
    {
        RequestView view = _requestViewFactory.Create();
        _mainUI.DisplayRequest(view);
    }

    public void DisplayDish(Dish dish)
    {
        DishView view = _dishViewFactory.Create(dish);
        _mainUI.AddDish(view);
    }

    public void DisplayError(string errorMessage)
    {
        ErrorView view = _errorViewFactory.Create(errorMessage);
        _mainUI.DisplayError(view);
    }
}