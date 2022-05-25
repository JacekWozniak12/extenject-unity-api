using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;
using UnityEngine.UI;
using System.Text;

public class ApiController : MonoBehaviour
{
    private string _api = "https://foodish-api.herokuapp.com/api/images/";
    public Image Display;
    public string FoodType;

    string[] foodTypes = 
    {
        "biryani", "burger", "butter-chicken", "dessert", "dosa", "idly", "pasta", "pizza", "rice", "samosa"
    }; 

    [ContextMenu("Show response")]
    public async void ShowDebugResponse()
    {
        Sprite a = await GetResponse(FoodType);
        Display.sprite = a;
    }

    public async Task<Sprite> GetResponse(string foodType)
    {
        if(foodType.Length <= 0) foodType = foodTypes[Random.Range(0, foodTypes.Length)];

        UnityWebRequest dishImageLinkRequest = UnityWebRequest.Get(_api+foodType);

        UnityWebRequest.Result linkResult = await dishImageLinkRequest.SendWebRequest();

        Debug.Log(dishImageLinkRequest.uri);
        Debug.Log(linkResult);
        Debug.Log(dishImageLinkRequest.downloadHandler.text);

        if (HasConnectionOrProtocolError(linkResult))
        {
            return null;
        }

        string imageLink = JsonUtility.FromJson<ImageLink>(dishImageLinkRequest.downloadHandler.text).image;

        UnityWebRequest dishImageRequest = UnityWebRequestTexture.GetTexture(imageLink);
        UnityWebRequest.Result imageResult = await dishImageRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(imageResult))
        {
            return null;
        }

        Texture2D tex = DownloadHandlerTexture.GetContent(dishImageRequest);

        Sprite sprite = Sprite.Create
        (
            tex,
            new Rect(0.0f, 0.0f, tex.width, tex.height),
            new Vector2(0.5f, 0.5f),
            100.0f);

        return sprite;
    }

    [System.Serializable]
    public struct ImageLink
    {
        public string image;
    }



    // async Task<UnityWebRequest.Result> SendRequest(
    //     string address,
    //     UnityWebRequest request
    // )
    // {

    // }

    bool HasConnectionOrProtocolError(UnityWebRequest.Result result)
        => result == UnityWebRequest.Result.ConnectionError ||
            result == UnityWebRequest.Result.ProtocolError;

}



