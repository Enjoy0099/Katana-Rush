using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool destroyEnemy;

    public void TakeDamage()
    {

        if(gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            SoundManager.instance.Play_EnemyDeath_Sound();
        }
        else
        {
            SoundManager.instance.Play_DestroyObstacle_Sound();
        }

        if (destroyEnemy)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }
}
