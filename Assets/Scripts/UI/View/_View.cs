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
}