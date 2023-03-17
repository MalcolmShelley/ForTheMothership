using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Camera cam;
    private Rigidbody2D player;
    private Rigidbody2D ground;
    private Rigidbody2D leftWall;
    private Rigidbody2D rightWall;
    private Rigidbody2D ceiling;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CameraScreen() {
        if (player.transform.position.x > ) {

        }
    }
    //X = -27, 27
    // = 7, 71
}
