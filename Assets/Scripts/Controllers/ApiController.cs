using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;

public class ApiController : Controller
{
    string _api = "https://foodish-api.herokuapp.com/api/images/";

    public override void Initialize()
    {
        Debug.Log("Api Controller Loaded");
    }

    public async Task<Response> GetResponse(FoodType foodType)
    {
        UnityWebRequest dishImageLinkRequest = UnityWebRequest.Get(_api + foodType);
        UnityWebRequest.Result linkResult = await dishImageLinkRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(linkResult))
        {
            return new Response(dishImageLinkRequest.error);
        }

        string imageLink = JsonUtility.FromJson<ImageLink>(dishImageLinkRequest.downloadHandler.text).Link;

        UnityWebRequest dishImageRequest = UnityWebRequestTexture.GetTexture(imageLink);
        UnityWebRequest.Result imageResult = await dishImageRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(imageResult))
        {
            return new Response(dishImageRequest.error);
        }

        Texture2D webTexture = DownloadHandlerTexture.GetContent(dishImageRequest);

        Sprite sprite = Sprite.Create
        (
            webTexture,
            new Rect(0.0f, 0.0f, webTexture.width, webTexture.height),
            new Vector2(0.5f, 0.5f),
            100.0f
            );

        return new Response(new Dish(foodType, sprite));
    }

    [System.Serializable]
    struct ImageLink { public string Link; }

    bool HasConnectionOrProtocolError(UnityWebRequest.Result result)
        => result == UnityWebRequest.Result.ConnectionError
        || result == UnityWebRequest.Result.ProtocolError;

}



