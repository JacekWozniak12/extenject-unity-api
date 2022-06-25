using UnityEngine.UIElements;
using Zenject;

public class ErrorView : View
{
    public ErrorView(VisualTreeAsset asset) : base(asset)
    {
    }

    public class Factory : PlaceholderFactory<ErrorView> { };


}