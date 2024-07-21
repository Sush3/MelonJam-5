using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    AudioSource currentMusic;
    public AudioMixerGroup mainMixer;
    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sound s in sounds)
        {
            s.Scource = gameObject.AddComponent<AudioSource>();
            s.Scource.clip = s.clip;
            s.Scource.volume = s.volume;
            s.Scource.pitch = s.pitch;
            s.Scource.loop = s.loop;
            s.Scource.outputAudioMixerGroup = mainMixer;
        }
        Play("Soundtrack");
    }

    public void Play(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        s.Scource.Play();
    }
    public void ChangePitch(string name,float x)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        s.pitch = x;
        s.Scource.pitch = x;
    }
    public float GetVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        return s.volume;
    }
    public void ChangeVolume(string name, float x)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        s.volume = x;
        s.Scource.volume = x;
    }
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        return s.Scource.isPlaying;
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
        }
        currentMusic = s.Scource;
        s.Scource.Play();
    }
    public bool isMusicPlaying()
    {
        return currentMusic.isPlaying;
    }
    public void PlayWalkingFootstep()
    {
        Play("WalkingFootstep");
    }
    public void PlayRunningFootstep()
    {
        Play("RunningFootstep");
    }
    public void PlayCrouchingFootstep()
    {
        Play("CrouchingFootstep");
    }
    public void PlayStrike()
    {
        Play("Strike");
    }
}
