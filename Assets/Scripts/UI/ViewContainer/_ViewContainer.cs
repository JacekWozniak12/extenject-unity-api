using System.Collections.Generic;
using UnityEngine;

public abstract class ViewContainer : MonoBehaviour
{
    [SerializeField]
    protected int _maxViewCount;
    
    [SerializeField]
    protected List<View> _viewList = new List<View>();
    
    [SerializeField]
    protected RectTransform _container;
}