using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public Animator anim;
    private bool isAlive = true;
    AudioSource enemyAudio;
    void Awake()
        {
            enemyAudio = GetComponent<AudioSource>();
        }
    public void TakeDamage (float damage)
    {
        if (!isAlive)
            return;
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Move(){

    }

    void Die()
    {
        if (isAlive)
        {
            GlobalManager.addScore(1000);
            enemyAudio.Play();
            isAlive = false;
            anim.SetTrigger("die");
        }
    }

    //used in death animation to remove object
    private void Remove()
    {
        Destroy(gameObject);
    }
}
