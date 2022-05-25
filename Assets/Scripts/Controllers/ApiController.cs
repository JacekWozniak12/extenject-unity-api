using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;
using UnityEngine.UI;
using System.Text;

public class ApiController : MonoBehaviour
{
    private string _apiLink = "https://foodish-api.herokuapp.com/api/";
    public Image Display;
    public string FoodType;

    [ContextMenu("Show response")]
    public async void ShowDebugResponse()
    {
        Sprite a = await GetResponse(FoodType);
        Display.sprite = a;
    }

    public async Task<Sprite> GetResponse(string foodType)
    {
        string body = $"/api/images/{foodType}";
        UnityWebRequest dishImageLinkRequest = UnityWebRequest.Get(_apiLink);

        dishImageLinkRequest.downloadHandler = new DownloadHandlerBuffer();
        dishImageLinkRequest.SetRequestHeader("accept", " text/plain");
        dishImageLinkRequest.SetRequestHeader("content-type", "text/plain");

        UnityWebRequest.Result linkResult = await dishImageLinkRequest.SendWebRequest();

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



