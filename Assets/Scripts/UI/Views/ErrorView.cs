using UnityEngine.UIElements;
using Zenject;

public class ErrorView : View
{
    string _errorMessage;

    public ErrorView(VisualTreeAsset asset, string errorMessage) : base(asset)
    {
        _errorMessage = errorMessage;
    }

    public class Factory : PlaceholderFactory<string, ErrorView> { };
}