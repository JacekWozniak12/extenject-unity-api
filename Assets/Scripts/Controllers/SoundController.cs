using UnityEngine;
using System.Linq;
using Zenject;

public class SoundController : Controller
{
    [Inject]
    AudioSource source;
    SoundData[] data;

    public override void Initialize()
    {
        source = new GameObject("Audio Source").AddComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        AudioClip[] sounds = data.First(x => x.Name == soundName).Clips;
        AudioClip sound = sounds[Random.Range(0, sounds.Length)];
        
        source.PlayOneShot(sound);
    }
}