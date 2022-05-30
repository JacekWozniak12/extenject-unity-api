using UnityEngine;
using System.Linq;
using Zenject;

public class SoundController : Controller
{
    AudioSource _source;
    SoundData[] _data;

    public override void Initialize()
    {
        _source = new GameObject("Audio Source").AddComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        try
        {
            AudioClip[] sounds = _data.First(x => x.Name == soundName).Clips;
            AudioClip sound = sounds[Random.Range(0, sounds.Length)];

            _source.PlayOneShot(sound);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Sound Controller reports:" + e.Message);
        }
    }
}