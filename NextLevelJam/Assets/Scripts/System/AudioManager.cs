using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    public SoundSO normalMusic, battleMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void PlayWithVar(string name, int var)
    {
        int num = UnityEngine.Random.Range(1, var + 1);
        name = name + num.ToString();
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void Fade(string name, bool fadeIn, float duration)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        float targetVolume = 0f;
        if (fadeIn)
        {
            targetVolume = s.source.volume;
        }
        StartCoroutine(Fade(name, fadeIn, s.source, duration, targetVolume));
    }

    private IEnumerator Fade(string name, bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (fadeIn)
        {
            Play(name);
            source.volume = 0f;
        }

        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }

        if (!fadeIn)
        {
            Stop(name);
            source.volume = startVol;
        }

        yield break;
    }

    public void ChangeVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.volume = volume;
    }

    public bool CheckIfPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
