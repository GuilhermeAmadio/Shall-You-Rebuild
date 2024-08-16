using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Stats/New Sound")]
public class SoundSO : ScriptableObject
{
    public string soundName;
    public int variations;

    public void Play()
    {
        if (variations != 0)
        {
            FindObjectOfType<AudioManager>().PlayWithVar(soundName, variations);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play(soundName);
        }
    }

    public void Stop()
    {
        FindObjectOfType<AudioManager>().Stop(soundName);
    }
}
