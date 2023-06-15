using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private GameObject damageCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAMETER);
    }

    public void PlayDeath()
    {
        anim.SetBool(TagManager.DEATH_ANIMATION_PARAMETER, true);
    }

    void ActivateDamageDetector()
    {
        damageCollider.SetActive(true);
    }

    void DeactivateDamageDetector()
    {
        damageCollider.SetActive(false);
    }

}
