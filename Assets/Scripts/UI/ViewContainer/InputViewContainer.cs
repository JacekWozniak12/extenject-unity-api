using UnityEngine;
using Zenject;

public class InputViewContainer : ViewContainer
{
    [SerializeField]
    RectTransform _errorViewContainer;

    [SerializeField]
    RectTransform _background;

    [Inject]
    RequestView _requestView;

    public void AddErrorView(ErrorView view)
    {
    }
}