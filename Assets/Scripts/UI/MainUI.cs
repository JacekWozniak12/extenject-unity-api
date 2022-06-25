using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

/// <summary>
/// Main UI handler, selects roots for view
/// </summary>
[RequireComponent(typeof(UIDocument))]
public class MainUI : MonoBehaviour, IInitializable
{
    VisualElement _errorRoot;
    VisualElement _requestRoot;
    ListView _contentRoot;

    [Inject]
    RequestView _requestView;

    public void Initialize() { }

    private void Start()
    {
        var document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;

        _errorRoot = root.Q<VisualElement>("Error");
        _contentRoot = root.Q<ListView>("Content");
        _requestRoot = root.Q<VisualElement>("Request");
    }

    public void DisplayError(ErrorView view)
    {
        view.CreateView(_errorRoot);
    }

    public void AddDish(DishView view)
    {
        view.CreateView(_contentRoot);
    }

    private void DisplayRequest(RequestView view) => view.CreateView(_requestRoot);


}
