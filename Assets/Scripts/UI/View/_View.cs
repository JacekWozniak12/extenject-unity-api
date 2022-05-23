using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class View : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI titleComponent;

    [SerializeField]
    protected Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() => Destroy(this.gameObject, 0.11f));
    }
}