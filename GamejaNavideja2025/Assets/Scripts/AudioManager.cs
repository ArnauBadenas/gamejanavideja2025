using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (var sound in Sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            
        }
    }

    // Update is called once per frame
    public void Play(string soundName)
    {
        Sound sound = Array.Find(Sounds, sound => sound.name == soundName);
        sound.source.Play();
    }
}
