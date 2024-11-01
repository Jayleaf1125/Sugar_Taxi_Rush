using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    public void Play (string name, float pitch, float volume, bool loop)
    {
        Sound s =  Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
        s.source.pitch = pitch;
        s.loop = loop;
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
            s.source.Pause();

       
    }
}
