using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public Animator anim;
    private bool isAlive = true;
    AudioSource enemyAudio;
    void Awake()
        {
            enemyAudio = GetComponent<AudioSource>();
        }
    public void TakeDamage (int damage)
    {
        if (!isAlive)
            return;
        enemyAudio.Play();
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
            isAlive = false;
            anim.SetTrigger("die");
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }

    private void GetEntities(){

    }
}
