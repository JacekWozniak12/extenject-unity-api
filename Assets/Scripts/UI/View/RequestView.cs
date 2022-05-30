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
    private ViewController _viewController;

    [Inject]
    readonly DishView.Factory _factory;

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(async () =>
        {
            Sprite sprite = await _apiController.GetResponse(_input.text);
            DishView view = _factory.Create();
            view.Create(_input.text, sprite);
            _viewController.DisplayDish(view);
        }
        );
    }
}