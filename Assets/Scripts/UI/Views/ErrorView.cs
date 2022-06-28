using UnityEngine.UIElements;
using Zenject;

public class ErrorView : View
{
    Label _errorTextContainer;
    Button _close;

    public ErrorView(string errorMessage, VisualTreeAsset asset) : base(asset)
    {
        _errorTextContainer = _instance.Q<Label>();
        _errorTextContainer.text = errorMessage;
        _close = _instance.Q<Button>();
        _close.clicked += () => _instance.parent.Remove(_instance);
    }

    public class Factory : PlaceholderFactory<string, ErrorView> { };
}