using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public Animator anim;
    private static float speed = 5f;

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
        if (GlobalManager.getPlayerHealth() == 0) {
            SceneManager.LoadScene(1); //Death Scene
        } else {
            float dirX = Input.GetAxis("Horizontal");

            player.velocity = new Vector2(dirX * speed * 2, player.velocity.y);

            float dirY = Input.GetAxis("Vertical");

            player.velocity = new Vector2(player.velocity.x, dirY * speed);

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

    public static void UpgradeSpeed() {
        speed *= 2;
    }
}
