using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationWithTransition : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayFromJumpToRunning(bool running)
    {
        anim.SetBool(TagManager.RUN_ANIMATION_PARAMETER, running);
    }

    public void PlayJump(float volY)
    {
        anim.SetFloat(TagManager.JUMP_ANIMATION_PARAMETER, volY);
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_ANIMATION_PARAMETER);
    }
}
