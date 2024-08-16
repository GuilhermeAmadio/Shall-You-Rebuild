using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Transform character;

    private bool flippedX;

    public void FlipX(bool flip)
    {
        if (flip)
        {
            if (!flippedX)
            {
                character.localScale = new Vector2(character.localScale.x * -1, character.localScale.y);
                flippedX = true;
            }
        }
        else
        {
            if (flippedX)
            {
                character.localScale = new Vector2(character.localScale.x * -1, character.localScale.y);
                flippedX = false;
            }
        }
    }
}
