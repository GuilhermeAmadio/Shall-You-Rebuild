using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public SoundSO sound;

    public void Play()
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}
