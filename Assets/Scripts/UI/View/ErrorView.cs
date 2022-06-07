using UnityEngine.UIElements;
using UnityEngine;
using Zenject;

public sealed class ErrorView : View
{
    public class Factory : PlaceholderFactory<ErrorView> { }

    [Header("Error View")]
    [SerializeField]
    private Label _descriptionLabel;
    private Label _titleLabel;

    GameObject _container;

    public void Create(string title, string information)
    {
        _titleLabel.text = title;
        _descriptionLabel.text = information;
        _functionButton.clicked +=
            () =>
            {
                
            };
    }

    public void SetContainer(GameObject gameObject)
    {
        _container = gameObject;
    }
}