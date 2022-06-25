using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

/// <summary>
/// Main UI handler, selects roots for view
/// </summary>
public class MainUI : MonoBehaviour
{
    VisualElement _errorRoot;
    VisualElement _requestRoot;
    ListView _contentRoot;

    [Inject]
    public void Init(PanelSettings settings, VisualTreeAsset asset)
    {
        UIDocument document = gameObject.AddComponent<UIDocument>();
        document.panelSettings = settings;
        document.visualTreeAsset = asset;
        
        VisualElement root = document.rootVisualElement;
        _errorRoot = root.Q<VisualElement>("Error");
        _contentRoot = root.Q<ListView>("Content");
        _requestRoot = root.Q<VisualElement>("Request");
    }

    public void DisplayRequest(RequestView view) => view.CreateView(_requestRoot);
    public void DisplayError(ErrorView view) => view.CreateView(_errorRoot);
    public void AddDish(DishView view) => view.CreateView(_contentRoot);
}
