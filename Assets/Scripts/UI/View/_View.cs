using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public abstract class View
{
    protected Button _functionButton;

    [Inject]
    protected SoundController _soundController;

    protected virtual void Initialize(VisualElement root, VisualTreeAsset asset)
    {
        _functionButton.clicked += () => _soundController.Play("UI_Click");
    }
}