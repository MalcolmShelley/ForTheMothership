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
            GlobalManager.addScore(100);

            Destroy(collision.gameObject);
        } else if(collision.gameObject.CompareTag("Pig"))
        {
            GlobalManager.addRations(3);
            GlobalManager.addScore(300);

            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Cow"))
        {
            GlobalManager.addRations(5);
            GlobalManager.addScore(500);

            Destroy(collision.gameObject);
        }
    }
}
