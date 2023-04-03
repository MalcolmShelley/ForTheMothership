using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public Animator anim;
    private bool isAlive = true;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            anim.SetTrigger("die");
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
