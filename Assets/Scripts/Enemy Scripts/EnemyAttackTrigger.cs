using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimation enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimation>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            enemyAnim.PlayAttack();

        }
    }
}
