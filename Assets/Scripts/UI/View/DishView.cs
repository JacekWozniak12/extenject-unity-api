using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.Events;

public sealed class DishView : View
{
    [Header("Dish View")]
    [SerializeField]
    private Image _image;

    public class Factory : PlaceholderFactory<DishView> { }

    public void Create(string title, Sprite foodImage, UnityAction onClean)
    {
        _image.sprite = foodImage;
        _image.preserveAspect = true;
        SetImageOversize(foodImage);
        _titleComponent.text = title;
        _functionButton.onClick.AddListener(onClean);
    }

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(() => Destroy(this.gameObject, 0.11f));
    }

    private void SetImageOversize(Sprite foodImage)
    {
        if (foodImage.rect.x > _image.rectTransform.rect.x)
        {
            float c = foodImage.rect.x / _image.rectTransform.rect.x;
            Debug.Log($"x:{c}");
        }
        else
        if (foodImage.rect.y > _image.rectTransform.rect.y)
        {
            float c = foodImage.rect.y / _image.rectTransform.rect.y;
            Debug.Log($"y:{c}");
        }
    }

}
