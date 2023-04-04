using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public Animator anim;
    private static float speed = 5f;

    private List<GameObject> entities;

    // Start is called before the first frame update
    private void Start()
    {
        this.player = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.anim.SetBool("EquipTraktor", false);
        this.anim.SetBool("EquipLaser", true);
        this.entities = new List<GameObject>();
        GetEntities();
    }

    // Update is called once per frame
    private void Update()
    {
        GetEntities();
        //Debug.Log("on scene: " + GlobalManager.getLevel() + " there are this many entities: " + entities.Count);
        if (GlobalManager.getPlayerHealth() == 0) {
            SceneManager.LoadScene(1); //Death Scene
        } else if(this.entities.Count == 0){
             SceneManager.LoadScene(2); // Upgrade Scene;
        }else {
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

    private void GetEntities(){
        this.entities.Clear();
        this.entities.AddRange(GameObject.FindGameObjectsWithTag("Chicken"));
        this.entities.AddRange(GameObject.FindGameObjectsWithTag("Pig"));
        this.entities.AddRange(GameObject.FindGameObjectsWithTag("Cow"));
        this.entities.AddRange(GameObject.FindGameObjectsWithTag("Farmer"));
    }
}
