using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private ScoreCounter scoreCounter;

    [SerializeField] private GameObject damageCollider;

    private float animSpeedThreshold = 0.2f, increaseSpeed_After = 20f;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Update()
    {
        if (scoreCounter.GetScore() > increaseSpeed_After)
        {
            increaseSpeed_After += 20f;
            anim.speed -= animSpeedThreshold;

        }
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAMETER);
        SoundManager.instance.Play_EnemyAttack_Sound();
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
