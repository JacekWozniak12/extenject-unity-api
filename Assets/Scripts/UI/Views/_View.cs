using UnityEngine.UIElements;
using Zenject;

public abstract class View
{
    [Inject]
    protected VisualTreeAsset _asset;
    
    public void CreateView(VisualElement at)
    {
        var obj = _asset.Instantiate();
        at.Add(obj);
    }
}