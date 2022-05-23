using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class ApiSystem : MonoBehaviour
{
    PopupSystem _popupSystem;

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



