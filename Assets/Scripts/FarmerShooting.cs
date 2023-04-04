using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    private GameObject gun;
    private float timer;

    public float timeBetweenAttacks = 5f;
    public int damage = 4;

    Transform player;
    

    void Awake()
    {
        gun = GameObject.FindGameObjectWithTag("shotgun");
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
        gun.GetComponent<AudioSource>().Play();
    }
}
