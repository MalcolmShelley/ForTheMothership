using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            GlobalManager.addRations(1);

            Destroy(collision.gameObject);
        } else if(collision.gameObject.CompareTag("Pig"))
        {
            GlobalManager.addRations(3);

            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Cow"))
        {
            GlobalManager.addRations(5);

            Destroy(collision.gameObject);
        }
    }
}
