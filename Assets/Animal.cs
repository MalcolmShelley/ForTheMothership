using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{
    public int value = 1;
    private Rigidbody2D animal;
    private bool isAbducted = false;
    //temp variable
    private static float speed = 5f;
    private Vector2 destinationPoint;
    private float minX, maxX;

    //make padding more elegant
    private float padding;

    private int direction;


    private List<GameObject> neighbours;


    void Start(){
        this.neighbours = new List<GameObject>();
        this.animal = GetComponent<Rigidbody2D>();
        this.padding = 0f;
        if(GlobalManager.getLevel() == 4){
            this.minX = -50f;
            this.maxX = 50f;
        }else if(GlobalManager.getLevel() == 5){
            this.minX = -18.8f;
            this.maxX = 6.4f;
        }
        
        this.destinationPoint = GetRandomPointWithinRange();
        GetEntities();
        foreach(var body in this.neighbours){
            //body.GetComponent<Rigidbody2D>().collisionDetectionMode = this.CollisionDetectionMode2D.Continuous;
            Physics2D.IgnoreCollision(body.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
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
        Debug.Log(GlobalManager.getLevel());
        if(GlobalManager.getLevel() == 4){
            this.minX = -50f;
            this.maxX = 50f;
        }else if(GlobalManager.getLevel() == 5){
            this.minX = -18f;
            this.maxX = 6f;
        }

        if(this.destinationPoint.x > this.maxX || this.destinationPoint.x < minX){
            StartCoroutine(WaitAndSetRandomDestination(2f));
        }

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
        this.direction = CalculateDirection();

        //Debug.Log(this.WithinPadding());

        if (this.CalculateDirection() == 0){
            StartCoroutine(WaitAndSetRandomDestination(2f));
        }
        
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.destinationPoint, speed * Mathf.Abs(direction) * Time.deltaTime);
        

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
        if(this.transform.position.x < this.destinationPoint.x){
            this.direction = 1;
            return this.direction;
        }else if(this.transform.position.x > this.destinationPoint.x){
            this.direction = -1;
            return this.direction;
        }
        
        this.direction = 0;
        return this.direction;
    }

    IEnumerator WaitAndSetRandomDestination(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.destinationPoint = GetRandomPointWithinRange();
    }

    public static void UpgradeTraktorSpeed() {
        speed *= 2;
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {   
        if(collision.gameObject.layer == 6){
            this.direction = 0;
            this.destinationPoint = GetRandomPointWithinRange();
            Debug.Log(this.name + " , " + this.destinationPoint);
        }
    }

}
