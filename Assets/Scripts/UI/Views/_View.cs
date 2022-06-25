using UnityEngine.UIElements;

public abstract class View
{
    protected VisualElement _instance;

    protected View(VisualTreeAsset asset)
    {
        _instance = asset.CloneTree();
    }

    public void CreateView(VisualElement at)
    {
        at.Add(_instance);
    }
}