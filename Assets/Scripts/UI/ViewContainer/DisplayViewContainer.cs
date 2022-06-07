using System.Collections.Generic;
using UnityEngine;

public sealed class DisplayViewContainer : ViewContainer
{
    [SerializeField]
    private int _maxViewCount = 9;

    [SerializeField]
    private List<View> _viewList = new List<View>();

    public void AddDishView(DishView view)
    {
        if (_viewList.Count == _maxViewCount && _viewList.Count > 0)
        {
            View temp = _viewList[0];
            _viewList.RemoveAt(0);
            
        }
        _viewList.Add(view);
    }

    public void ClearDish(DishView view)
    {
        _viewList.Remove(view);
    }
}