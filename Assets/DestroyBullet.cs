using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
=======
>>>>>>> Stashed changes
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
