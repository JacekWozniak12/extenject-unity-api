using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;

public class ApiController : Controller
{
    [Inject]
    ViewController _popupController;

    public override void Initialize()
    {
        // Get Random Image
    }

    

    // async Task<UnityWebRequest.Result> SendRequest(
    //     string address,
    //     UnityWebRequest request
    // )
    // {

    // }

    bool HasConnectionOrProtocolError(UnityWebRequest.Result result)
        =>  result == UnityWebRequest.Result.ConnectionError || 
            result == UnityWebRequest.Result.ProtocolError;

}



