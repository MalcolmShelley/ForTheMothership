using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{
    private Rigidbody2D animal;
    private bool isAbducted = false;
    private float speed = 5f;
    private Vector2 destinationPoint;
    private float minX, maxX;

    //make padding more elegant
    private float padding = 3f;

    private List<GameObject> neighbours;


    void Start(){
        this.neighbours = new List<GameObject>();
        this.animal = GetComponent<Rigidbody2D>();
        this.minX = -50f;
        this.maxX = 50f;
        this.destinationPoint = GetRandomPointWithinRange();
    }

    public void Abduct()
    {
        this.isAbducted = true;
    }

    public void Drop()
    {
        this.isAbducted = false;
    }
    void Update()
    {
        //TODO FIX ABDUCTION
        if (this.isAbducted){
            this.animal.velocity = new Vector2(animal.velocity.x, speed * Time.deltaTime);
        }
        Move();
        GetEntities();
        if (Vector2.Distance(transform.position, destinationPoint) < 5f){
            StartCoroutine(WaitAndSetRandomDestination(2f));
        }
            
            
    }     
    

    void Move(){
        int direction = CalculateDirection();

        //Debug.Log(this.WithinPadding());

        //Debug.Log(direction);

        if (this.WithinPadding() == true || this.CalculateDirection() == 0){
            direction = 0;
            //Debug.Log(this.name + " here!");
            this.destinationPoint = GetRandomPointWithinRange();
            //Debug.Log(this.name + " is here: " + this.GetCurrentPosition() +  "  and is headed to: " + this.destinationPoint);
        }
        
        //Debug.Log(direction);
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.destinationPoint, this.speed * Mathf.Abs(direction) * Time.deltaTime);
        

    }

    private Vector2 GetRandomPointWithinRange(){
       //fix distance
        
        float x = this.transform.position.x;
        
        while(Mathf.Abs(this.transform.position.x - x) < 10){
            x = Random.Range(minX, maxX);
        } 
        float y = this.transform.position.y;

        return new Vector2(x, y);
    }

    private Vector2 GetCurrentPosition(){
        return new Vector2(this.transform.position.x, this.transform.position.y);
    }

    private bool WithinPadding(){
        foreach (var entity in neighbours){
            if(entity != null && entity.GetComponent<BoxCollider2D>() != null){
                this.padding = entity.GetComponent<BoxCollider2D>().bounds.size.x *1.5f;
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

    private void GetEntities(){
        this.neighbours.Clear();
        this.neighbours.AddRange(GameObject.FindGameObjectsWithTag("Chicken"));
        this.neighbours.AddRange(GameObject.FindGameObjectsWithTag("Pig"));
        this.neighbours.AddRange(GameObject.FindGameObjectsWithTag("Cow"));
        this.neighbours.AddRange(GameObject.FindGameObjectsWithTag("Farmer"));
    }

    public int CalculateDirection(){
        if(this.transform.position.x < this.destinationPoint.x - 1.5){
            return 1;
        }else if(this.transform.position.x > this.destinationPoint.x + 1.5){
            return -1;
        }

        return 0;
    }

    IEnumerator WaitAndSetRandomDestination(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GetRandomPointWithinRange();
    }

}
