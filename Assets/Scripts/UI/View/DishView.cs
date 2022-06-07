using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using UnityEngine.Events;

public sealed class DishView : View
{
    public class Factory : PlaceholderFactory<DishView> { }

    private Label _titleLabel;
    private Image _image;

    public void Create(string title, Sprite foodImage, UnityAction onClean)
    {
        _image.sprite = foodImage;
        _titleLabel.text = title;
        _functionButton.clicked += () => onClean();
    }

    protected void Initialize()
    {
        // base.Initialize();

        // _functionButton.clicked += () => Destroy(this.gameObject, 0.11f);
    }
}
