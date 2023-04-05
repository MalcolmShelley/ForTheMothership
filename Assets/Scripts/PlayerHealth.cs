using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int startingHealth;
    private int currentHealth;
    public Slider healthSlider;
    void Awake()
    {
        startingHealth = GlobalManager.getPlayerHealth();
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        SceneManager.LoadScene(1); //Death Scene
    }
    public int getHealth()
    {
        return currentHealth;
    }
}
