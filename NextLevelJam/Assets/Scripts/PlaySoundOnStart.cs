using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public SoundSO sound;

    private void Start()
    {
        sound.Play();
    }
}
