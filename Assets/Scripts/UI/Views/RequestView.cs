using Zenject;
using UnityEngine.UIElements;
using UnityEngine;

public class RequestView : View
{
    Button _buttonRequest;
    TextField _textRequest;
    InputController inputController;

    public RequestView(VisualTreeAsset asset, InputController inputController) : base(asset)
    {
        _textRequest = _instance.Q<TextField>("Request");
        _buttonRequest = _instance.Q<Button>("Confirm");
        _buttonRequest.clicked += () => inputController.SendRequest(_textRequest.text);
    }

    public class Factory : PlaceholderFactory<RequestView> { };

}