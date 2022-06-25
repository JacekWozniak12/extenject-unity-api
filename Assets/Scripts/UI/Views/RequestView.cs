using Zenject;
using UnityEngine.UIElements;

public class RequestView : View
{
    public RequestView(VisualTreeAsset asset) : base(asset)
    {
    }

    public class Factory : PlaceholderFactory<RequestView> { };
    
}