using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using UnityEngine.Events;

public sealed class DishView : View
{
    public class Factory : PlaceholderFactory<DishView> { }

    [Header("Dish View")]
    [SerializeField]
    private Image _image;

    public void Create(string title, Sprite foodImage, UnityAction onClean)
    {
        _image.sprite = foodImage;
        _titleComponent.text = title;
        _functionButton.clicked += () => onClean();
    }

    protected override void Awake()
    {
        base.Awake();
        _functionButton.clicked += () => Destroy(this.gameObject, 0.11f);
    }
}
