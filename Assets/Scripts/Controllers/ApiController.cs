using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class ApiController : Controller
{
    private string _api = "https://foodish-api.herokuapp.com/api/images/";  
     
    string[] foodTypes = 
    {
        "biryani", "burger", "butter-chicken", "dessert", "dosa", "idly", "pasta", "pizza", "rice", "samosa"
    }; 

    public async Task<Sprite> GetResponse(string foodType)
    {
        foodType = GetRandomFoodIfEmpty(foodType);
        foodType = foodType.ToLower();

        UnityWebRequest dishImageLinkRequest = UnityWebRequest.Get(_api + foodType);
        UnityWebRequest.Result linkResult = await dishImageLinkRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(linkResult))
            return null;

        string imageLink = JsonUtility.FromJson<ImageLink>(dishImageLinkRequest.downloadHandler.text).image;

        UnityWebRequest dishImageRequest = UnityWebRequestTexture.GetTexture(imageLink);
        UnityWebRequest.Result imageResult = await dishImageRequest.SendWebRequest();

        if (HasConnectionOrProtocolError(imageResult))
            return null;

        Texture2D webTexture = DownloadHandlerTexture.GetContent(dishImageRequest);

        Sprite sprite = Sprite.Create
        (
            webTexture,
            new Rect(0.0f, 0.0f, webTexture.width, webTexture.height),
            new Vector2(0.5f, 0.5f),
            100.0f);

        return sprite;
    }

    private string GetRandomFoodIfEmpty(string foodType)
    {
        if (foodType.Length <= 0) foodType = foodTypes[Random.Range(0, foodTypes.Length)];
        return foodType;
    }

    [System.Serializable]
    public struct ImageLink
    {
        public string image;
    }


    bool HasConnectionOrProtocolError(UnityWebRequest.Result result)
        => result == UnityWebRequest.Result.ConnectionError || result == UnityWebRequest.Result.ProtocolError;

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }
}



