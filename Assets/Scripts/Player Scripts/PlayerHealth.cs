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
        health--;

        if (health <= 0)
        {
            // Game Over Panel
            GameObject.FindWithTag(TagManager.GAMEPLAY_CONTROLLER_TAG).
                                    GetComponent<GameOverController>().GameOverShowPanel();

            Destroy(gameObject);
        }
        healthBars[currentHealthBarIndex].SetActive(false);

        currentHealthBarIndex++;

        if (currentHealthBarIndex <= (healthBars.Length - 1))
            healthBars[currentHealthBarIndex].SetActive(true);
        
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
