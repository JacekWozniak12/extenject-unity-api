using UnityEngine;
using Zenject;

public class InputViewContainer : ViewContainer
{
    [SerializeField]
    RectTransform _errorViewContainer;

    [Inject]
    RequestView _requestView;

    public void AddErrorView(ErrorView view)
    {
        view.transform.SetParent(_errorViewContainer.parent, false);
        view.SetStretched();
    }
}