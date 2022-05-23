using UnityEngine;
using UnityEngine.UI;

public sealed class DishView : View
{
    [Header("Dish View")]
    [SerializeField]
    private Image _image;

    public void Create(string title, Sprite foodImage)
    {
        _image.sprite = foodImage;
        _titleComponent.text = title;
    }

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(() => Destroy(this.gameObject, 0.11f));
    }
}
