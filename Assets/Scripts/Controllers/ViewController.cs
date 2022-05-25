using UnityEngine;
using Zenject;

public class ViewController : Controller
{
    [Inject]
    DisplayViewContainer _displayViewContainer;
    
    [Inject]
    InputViewContainer _inputViewContainer;

    public override void Initialize()
    {
        
    }

    public void ShowErrorMessage()
    {

    }
}