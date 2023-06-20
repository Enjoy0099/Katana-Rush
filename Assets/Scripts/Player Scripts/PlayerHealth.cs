using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject[] healthBars;

    private int currentHealthBarIndex;

    private int health;

    private void Start()
    {
        health = healthBars.Length;
        currentHealthBarIndex = 0;
    }

    public void SubtractHealth()
    {
        if (health <= 0)
            return;

        healthBars[currentHealthBarIndex].SetActive(false);

        currentHealthBarIndex++;
        
        if (currentHealthBarIndex < (healthBars.Length))
        {
            healthBars[currentHealthBarIndex].SetActive(true);
        }
        
        health--;

        if (health <= 0)
        {
            // Game Over Panel


            Destroy(gameObject);
        }
    }


    public void AddHealth()
    {
        if (health == healthBars.Length)
            return;

        healthBars[currentHealthBarIndex].SetActive(false);

        currentHealthBarIndex--;

        healthBars[currentHealthBarIndex].SetActive(true);

        health++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.HEALTH_TAG))
        {
            AddHealth();

            collision.gameObject.SetActive(false);
        }
    }

}
