using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    public IntSO charDamage;

    public int GetDamage()
    {
        return charDamage.value;
    }
}
