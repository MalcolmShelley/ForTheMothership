using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            GlobalManager.instance.addRations(1);

            Destroy(collision.gameObject);
        }
    }
}
