using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpeed : MonoBehaviour
{
    public FloatSO charSpeed;

    public float GetBaseSpeed()
    {
        return charSpeed.value;
    }
}
