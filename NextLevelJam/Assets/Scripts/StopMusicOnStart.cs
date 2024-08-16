using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicOnStart : MonoBehaviour
{
    public SoundSO sound;

    private void Start()
    {
        sound.Stop();
    }
}
