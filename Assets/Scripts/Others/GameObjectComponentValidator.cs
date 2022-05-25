using UnityEngine;

public static class GameObjectComponentValidator
{
    public static bool ValidateGameObject<T>(this GameObject gameObject) where T: Component
    {
        if(gameObject.GetComponent<T>() == null)
        {
            Debug.LogWarning($"GameObject {gameObject} does not have component {typeof(T)}", gameObject);
            return false;
        }

        return true;
    }
}