using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{
    private Rigidbody2D animal;
    private bool isAbducted = false;
    private static float speed = 5f;

    public void Abduct()
    {
        isAbducted = true;
    }

    public void Drop()
    {
        isAbducted = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isAbducted)
        {
            float dirY = Input.GetAxis("Vertical");
            animal.velocity = new Vector2(animal.velocity.x, speed);
        }
    }

    public static void UpgradeTraktorSpeed() {
        speed *= 2;
    }
}
