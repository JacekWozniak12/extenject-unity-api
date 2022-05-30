using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Zenject;

public sealed class ErrorView : View
{
    [Header("Error View")]
    [SerializeField]
    private TextMeshProUGUI _descriptionComponent;

    public void Create(string title, string information)
    {
        _titleComponent.text = title;
        _descriptionComponent.text = information;
    }

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(() => Destroy(this.gameObject, 0.11f));
    }

    public class Factory : PlaceholderFactory<ErrorView> { }
}