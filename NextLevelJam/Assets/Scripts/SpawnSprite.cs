using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSprite : MonoBehaviour
{
    public SpriteRenderer startSR;
    public SpriteRenderer newSR;

    public GameObject spriteObj;
    public Animator anim;
    private GameObject sprite;
    private AnimationChanger spriteAnim;

    public void ChangeAnimAnimation(string animation, bool check)
    {
        anim.SetBool(animation, check);
    }

    public void ChangeSpriteAnimation(string animation, bool check)
    {
        spriteAnim.ChangeAnimBool(animation, check);
    }

    private void OnEnable()
    {
        sprite = Instantiate(spriteObj, transform.position, Quaternion.identity);
        sprite.GetComponent<TargetFollow>().target = this.transform;
        anim = sprite.GetComponent<Animator>();
        spriteAnim = sprite.GetComponentInChildren<AnimationChanger>();
        newSR = sprite.GetComponentInChildren<SpriteRenderer>();

        startSR.enabled = false;
    }

    private void OnDisable()
    {
        Destroy(sprite);
    }
}
