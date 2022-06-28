using UnityEngine.UIElements;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

/// <summary>
/// Main UI handler, selects roots for view
/// </summary>
public class MainUI : MonoBehaviour
{
    VisualElement _errorRoot;
    VisualElement _requestRoot;
    ScrollView _contentRoot;

    List<DishView> _dishes;
    DishView.Factory _dishViewFactory;

    [Inject]
    public void Init(PanelSettings settings, VisualTreeAsset asset)
    {
        UIDocument document = gameObject.AddComponent<UIDocument>();
        document.panelSettings = settings;
        document.visualTreeAsset = asset;

        VisualElement root = document.rootVisualElement;
        _errorRoot = root.Q<VisualElement>("Error");
        _contentRoot = root.Q<ScrollView>("List");
        _requestRoot = root.Q<VisualElement>("Request");

        _dishes = new List<DishView>();
    }

    public void DisplayRequest(RequestView view) => view.CreateView(_requestRoot);
    public void DisplayError(ErrorView view)
    {
        _errorRoot.hierarchy.Clear();
        view.CreateView(_errorRoot);
    }

    public void AddDish(DishView dish)
    {
        _dishes.Insert(0, dish);
        dish.AddCloseAction(() => RemoveDish(dish));
        CleanScrollView();
        PopulateScrollView();
    }

    public void RemoveDish(DishView dish)
    {
        _dishes.Remove(dish);
        CleanScrollView();
        PopulateScrollView();
    }

    public void CleanScrollView()
    {
        _contentRoot.Clear();
    }

    public void PopulateScrollView()
    {
        foreach (DishView v in _dishes)
        {
            _contentRoot.Add(v.GetElement());
        }
    }
}
