using System.Collections.Generic;
using UnityEngine;

public class DisplayViewContainer : ViewContainer
{
    [SerializeField]
    protected int _maxViewCount = 50;

    [SerializeField]
    protected List<View> _viewList = new List<View>();

}