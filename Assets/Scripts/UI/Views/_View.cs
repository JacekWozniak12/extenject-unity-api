using UnityEngine.UIElements;
using Zenject;

[System.Serializable]
public abstract class View
{
    protected VisualTreeAsset _asset;

    protected View(VisualTreeAsset asset)
    {
        _asset = asset;
    }

    public void CreateView(VisualElement at)
    {
        var obj = _asset.Instantiate();
        at.Add(obj);
    }
}