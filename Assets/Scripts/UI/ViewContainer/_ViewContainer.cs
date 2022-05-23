using System.Collections.Generic;
using UnityEngine;

public abstract class ViewContainer : MonoBehaviour
{    
    [SerializeField]
    protected RectTransform _container;

    protected virtual void Awake()
    {
        // as reminder that awake is used
    }
}