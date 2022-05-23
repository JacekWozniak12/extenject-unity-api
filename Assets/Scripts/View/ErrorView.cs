using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class ErrorView : View
{
    [Inject]
    PopupController _popupController;
    
    TextMeshProUGUI textComponent;
    Button button;
}