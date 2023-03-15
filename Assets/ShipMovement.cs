using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("EquipTraktor", false);
        anim.SetBool("EquipLaser", true);
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(dirX * 10f, player.velocity.y);

        float dirY = Input.GetAxis("Vertical");

        player.velocity = new Vector2(player.velocity.x, dirY * 5f);

        if (Input.GetButton("Jump") && !Input.GetButton("Fire1"))
        {
            anim.SetBool("EquipLaser", false);
            anim.SetBool("EquipTraktor", true);
        }
        if (Input.GetButton("Fire1") && !Input.GetButton("Jump"))
        {
            anim.SetBool("EquipTraktor", false);
            anim.SetBool("EquipLaser", true);
        }
    }
}
