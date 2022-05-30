using UnityEngine;
using Zenject;

public class ViewController : Controller
{
    [Inject]
    DisplayViewContainer _displayViewContainer;

    [Inject]
    InputViewContainer _inputViewContainer;

    public override void Initialize()
    {

    }

    public void DisplayDish(DishView view)
    {
        _displayViewContainer.AddDishView(view);
    }

    public void DisplayError(ErrorView view)
    {
        _inputViewContainer.AddErrorView(view);
    }
}