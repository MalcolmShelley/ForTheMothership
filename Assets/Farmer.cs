using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Enemy
{
    private Rigidbody2D farmer;
    private List<GameObject> flock;
    private float speed;
    private float padding;
    void Start(){
        this.farmer = this.GetComponent<Rigidbody2D>();
        this.flock = new List<GameObject>();
        this.speed = 3f;
        GetEntities();
        
    }
    
    void Move(){
        int direction = CalculateDirection();
        Debug.Log(direction);
        this.transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        

        
    }


    public int CalculateDirection(){
        int right = 0;
        int left = 0;

        foreach (var animal in this.flock){
            if (animal.transform.position.x < this.transform.position.x){
                if(animal.tag == "Chicken"){
                    left ++;
                }else if(animal.tag == "Pig"){
                    left += 3;
                }else if(animal.tag == "Cow"){
                    left += 5;
                }
                
            }else if(animal.transform.position.x > this.transform.position.x){
                if(animal.tag == "Chicken"){
                    right ++;
                }else if(animal.tag == "Pig"){
                    right += 3;
                }else if(animal.tag == "Cow"){
                    right += 5;
                }
            }
        }

        Debug.Log(left + "," + right);

        if(left > right){
            return -1;
        }else if(right > left){
            return 1;
        }else{
            return 0;
        }
        
    }

    void Update(){
        GetEntities();
        Move();
    }

    private void GetEntities(){
        this.flock.Clear();
        this.flock.AddRange(GameObject.FindGameObjectsWithTag("Chicken"));
        this.flock.AddRange(GameObject.FindGameObjectsWithTag("Pig"));
        this.flock.AddRange(GameObject.FindGameObjectsWithTag("Cow"));
        this.flock.AddRange(GameObject.FindGameObjectsWithTag("Farmer"));
        

    }

    private bool WithinPadding(){
        foreach (var entity in flock){
            if(entity != null && entity.GetComponent<BoxCollider2D>() != null){
                this.padding = entity.GetComponent<BoxCollider2D>().bounds.size.x;
                //this.padding = 20;
                if (this.transform.position.x > entity.transform.position.x - this.padding && this.transform.position.x < entity.transform.position.x + this.padding && this.name != entity.name){
                    if(CalculateDirection() == 1 && this.transform.position.x > entity.transform.position.x){
                        break;
                    }else if(CalculateDirection() == -1 && this.transform.position.x < entity.transform.position.x){
                        break;
                    }
                    return true;
                }
            }
        }
        return false;
    }
}
