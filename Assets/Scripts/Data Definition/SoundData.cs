using UnityEngine;

[CreateAssetMenu(
    fileName = "SoundData", 
    menuName = "extenject-unity-api/SoundData", order = 0)
    ]
public class SoundData : ScriptableObject
{
    public AudioClip[] Clips;
}