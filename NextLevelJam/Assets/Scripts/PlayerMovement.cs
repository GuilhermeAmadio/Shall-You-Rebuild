using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform charTransform;
    public CharMovement charMovement;
    public Flip flip;

    private Vector2 move;

    public void MoveInput(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

        charMovement.ChangeMove(move);

        if (move.x < 0)
        {
            flip.FlipX(false);
        }
        else if (move.x > 0)
        {
            flip.FlipX(true);
        }
    }
}
