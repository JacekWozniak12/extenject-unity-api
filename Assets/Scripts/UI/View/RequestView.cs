using UnityEngine;
using TMPro;
using Zenject;

public sealed class RequestView : View
{
    [Header("Request View")]
    [SerializeField]
    private TMP_InputField _input;

    [Inject] private InputController _inputController;

    protected override void Awake()
    {
        base.Awake();
        string food = "Dishes available:\n";

        foreach (string f in FoodTypeController.FoodTypesNames)
        {
            food += $"{f}, ";
        }
        food = food.Substring(0, food.Length - 2);
        food += "."; 

        _functionButton.onClick.AddListener(() => _inputController.SendRequest(_input.text));
        _input.placeholder.GetComponent<TextMeshProUGUI>().text = food;
    }
};