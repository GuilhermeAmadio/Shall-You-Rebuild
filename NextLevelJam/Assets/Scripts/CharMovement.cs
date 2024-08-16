using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public CharacterSpeed charSpeed;

    private bool canMove = true;

    private Vector2 move;

    public Rigidbody rb;
    public Animator anim;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!canMove)
        {
            return;
        }

        rb.velocity = new Vector3(move.x, 0f, move.y).normalized * charSpeed.GetBaseSpeed();

        if (rb.velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }

    public void ChangeMove(Vector2 move)
    {
        this.move = move;
    }
}
