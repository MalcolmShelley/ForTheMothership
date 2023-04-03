using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{
    public int value = 1;
    private Rigidbody2D animal;
    private bool isAbducted = false;

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
            animal.velocity = new Vector2(animal.velocity.x, 5f);
        }
    }
}
