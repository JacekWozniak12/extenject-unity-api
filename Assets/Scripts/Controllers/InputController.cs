using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;

public class InputController : Controller
{
    [Inject] private ApiController _apiController;
    [Inject] private FoodTypeController _foodTypeController;
    [Inject] private ViewController _viewController;

    public override void Initialize() { }

    public async void SendRequest(string text)
    {
        FoodType foodType = _foodTypeController.GetFoodType(text);
        Response response = await _apiController.GetResponse(foodType);
        _viewController.DisplayDish(response.Dish);
    }
}