using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 20;
    public int currentHealth;
    public Slider healthSlider;
    LaserSound laserSound;
    TraktorSound traktorSound;
    laser laser;
    FireTraktor TraktorFunction;
    ShipMovement shipMovement;

    bool dead;
    
    void Awake()
    {
        laserSound = GetComponent<LaserSound>();
        traktorSound = GetComponent<TraktorSound>();
        laser = GetComponent<laser>();
        TraktorFunction = GetComponent<FireTraktor>();
        shipMovement = GetComponent<ShipMovement>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !dead)
        {
            Kill();
        }
    }

    void Kill()
    {
        dead = true;
        laserSound.enabled = false;
        traktorSound.enabled = false;
        laser.enabled = false;
        TraktorFunction.enabled = false;
        shipMovement.enabled = false;
    }
}
