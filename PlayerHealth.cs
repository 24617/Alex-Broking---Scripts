using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private GameObject allHealth;
    private Image[] health;
    private int fullHealth = 6;
    private int currentHealth = 4;
    private Sprite fullHeart;
    private Sprite emptyHeart;

    void Start()
    {
        fullHeart = Resources.Load<Sprite>("Sprites/fullHeart");
        emptyHeart = Resources.Load<Sprite>("Sprites/emptyHeart");
        allHealth = GameObject.Find("Health");
        health = allHealth.GetComponentsInChildren<Image>();
    }

	void Update () {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < currentHealth)
            {
                health[i].sprite = fullHeart;
            }
            else
            {
                health[i].sprite = emptyHeart;
            }
            if (i < fullHealth)
            {
                health[i].enabled = true;

            }
            else
            {
                health[i].enabled = false;
            }
        }
    }

    public void RemoveHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth == 0)
        {
            PlayerDie();
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    private void PlayerDie()
    {
        print("player died");
    }
}
