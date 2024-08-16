using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    public Animator anim;

    public void ChangeAnimBool(string animation, bool check)
    {
        anim.SetBool(animation, check);
    }
}
