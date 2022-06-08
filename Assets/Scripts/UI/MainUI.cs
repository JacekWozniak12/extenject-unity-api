using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

/// <summary>
/// Main UI handler, selects roots for view
/// </summary>
[RequireComponent(typeof(UIDocument))]
public class MainUI : MonoBehaviour
{
    VisualElement _errorRoot;
    VisualElement _requestRoot;
    ListView _contentRoot;

    RequestView _requestView;

    [Inject] 
    RequestView.Factory _requestViewFactory;

    private void Awake()
    {
        var document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;

        _errorRoot = root.Q<VisualElement>("Error");
        _contentRoot = root.Q<ListView>("Content");
        _requestRoot = root.Q<VisualElement>("Request");

        _requestView = _requestViewFactory.Create();
    }
}
