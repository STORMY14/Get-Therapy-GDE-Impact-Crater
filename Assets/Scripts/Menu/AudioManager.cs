using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound current_sound in sounds)
        {
            current_sound.source = gameObject.AddComponent<AudioSource>();
            current_sound.source.clip = current_sound.clip;
            current_sound.source.volume = current_sound.volume;
        }
    }

    public void PlaySound(string name)
    {
        Sound current_sound = Array.Find(sounds, sound => sound.name == name);
        current_sound.source.Play();
    }
}
