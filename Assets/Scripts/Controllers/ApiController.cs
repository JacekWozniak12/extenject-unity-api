using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using Zenject;

public class ApiController : Controller
{
    string _api = "https://foodish-api.herokuapp.com/api/images/";

    [Inject]
    ViewController _viewController;

    public override void Initialize() { }

    public async Task<Sprite> GetResponse(FoodType foodType)
    {
        UnityWebRequest dishImageLinkRequest = UnityWebRequest.Get(_api + foodType);
        UnityWebRequest.Result linkResult = await dishImageLinkRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(linkResult))
        {
            _viewController.DisplayError("API ERROR", dishImageLinkRequest.error);
            return null;
        }

        string imageLink = JsonUtility.FromJson<ImageLink>(dishImageLinkRequest.downloadHandler.text).Link;

        UnityWebRequest dishImageRequest = UnityWebRequestTexture.GetTexture(imageLink);
        UnityWebRequest.Result imageResult = await dishImageRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(imageResult))
        {
            _viewController.DisplayError("IMAGE SRC ERROR", dishImageRequest.error);
            return null;
        }

        Texture2D webTexture = DownloadHandlerTexture.GetContent(dishImageRequest);

        Sprite sprite = Sprite.Create
        (
            webTexture,
            new Rect(0.0f, 0.0f, webTexture.width, webTexture.height),
            new Vector2(0.5f, 0.5f),
            100.0f
            );

        return sprite;
    }

    [System.Serializable]
    public struct ImageLink
    {
        public string Link;
    }

    bool HasConnectionOrProtocolError(UnityWebRequest.Result result)
        => result == UnityWebRequest.Result.ConnectionError ||
            result == UnityWebRequest.Result.ProtocolError;

}



