using UnityEngine;
using TMPro;
using Zenject;

public sealed class RequestView : View
{
    [Header("Request View")]
    [SerializeField]
    private TMP_InputField _input;

    [Inject]
    private ApiController _apiController;

    [Inject]
    private FoodTypeController _foodTypeController;

    [Inject]
    private ViewController _viewController;

    [Inject]
    readonly DishView.Factory _factory;

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(async () =>
        {
            FoodType foodType = _foodTypeController.GetFoodType(_input.text);
            Sprite sprite = await _apiController.GetResponse(foodType);
            DishView view = _factory.Create();
            view.Create(foodType, sprite);
            _viewController.DisplayDish(view);
        }
        );
    }
}