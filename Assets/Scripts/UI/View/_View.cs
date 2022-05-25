using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class View : MonoBehaviour
{
    [Header("View")]
    [SerializeField]
    protected TextMeshProUGUI _titleComponent;

    [SerializeField]
    protected Button _functionButton;

    [Inject]
    protected SoundController _soundController;

    protected virtual void Awake()
    {
        _functionButton.onClick.AddListener(() => _soundController.Play("UI_Click"));
    }

    public void SetStretched()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.pivot = 0.5f * Vector2.one;
    }
}