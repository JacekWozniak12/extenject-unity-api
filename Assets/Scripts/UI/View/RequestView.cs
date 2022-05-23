using UnityEngine;
using TMPro;
using Zenject;

public sealed class RequestView : View
{
    [Header("Request View")]
    [SerializeField]
    private TMP_InputField _input;

    [Inject]
    private ApiController _apiController;

    protected override void Awake()
    {
        base.Awake();
        _functionButton.onClick.AddListener(() => Debug.Log(""));
    }
}