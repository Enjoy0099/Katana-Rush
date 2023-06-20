using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool destroyEnemy;

    public void TakeDamage()
    {
        if (destroyEnemy)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }
}
