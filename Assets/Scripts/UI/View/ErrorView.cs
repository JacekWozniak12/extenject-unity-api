using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Zenject;

public sealed class ErrorView : View
{
    [Header("Error View")]
    [SerializeField]
    private TextMeshProUGUI _descriptionComponent;

    GameObject _container;

    public void Create(string title, string information)
    {
        _titleComponent.text = title;
        _descriptionComponent.text = information;
        _functionButton.onClick.AddListener(
            () =>
            {
                Destroy(this.gameObject, 0.11f);
                _container?.SetActive(false);
            }
            );
    }

    public void SetContainer(GameObject gameObject)
    {
        _container = gameObject;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public class Factory : PlaceholderFactory<ErrorView> { }
}