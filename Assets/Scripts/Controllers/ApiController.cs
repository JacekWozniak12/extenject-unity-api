using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;

public class ApiController : Controller
{
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



