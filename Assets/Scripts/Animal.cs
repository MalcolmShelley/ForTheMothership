using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Enemy
{
    private Rigidbody2D animal;
    private bool isAbducted = false;
    private bool isFalling = false;
    private float horizontalSpeed = 4f;
    private Vector2 destinationPoint;
    private float minX, maxX;
    private List<GameObject> neighbours;


    void Start(){
        //initiate variables
        this.neighbours = new List<GameObject>();
        this.animal = GetComponent<Rigidbody2D>();
        if(GlobalManager.getLevel() == 4 || GlobalManager.getLevel() == 6){
            this.minX = -50f;
            this.maxX = 50f;
        }else if(GlobalManager.getLevel() == 5){
            this.minX = -18.5f;
            this.maxX = 6f;
        }
        this.destinationPoint = GetRandomPointWithinRange();
        GetEntities();
        foreach(var body in this.neighbours){
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
        this.isFalling = true;
    }
    void Update()
    {
        if(GlobalManager.getLevel() == 4 || GlobalManager.getLevel() == 6){
            this.minX = -50f;
            this.maxX = 50f;
        }else if(GlobalManager.getLevel() == 5){
            this.minX = -18.5f;
            this.maxX = 6f;
        }

        if (this.isAbducted){
            this.animal.velocity = new Vector2(animal.velocity.x, GlobalManager.getTraktorSpeed());
        }
        CheckIfFalling();
        Move();
        GetEntities();
        if (Vector2.Distance(transform.position, destinationPoint) < 5f){
            StartCoroutine(WaitAndSetRandomDestination(2f));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFalling)
        {
            this.isFalling = false;
        }
    }


    void Move(){
        if (!this.isAbducted && !this.isFalling)
        {
            int direction = CalculateDirection();

            if (this.CalculateDirection() == 0)
            {
                WaitAndSetRandomDestination(2f);
            }

            this.transform.position = Vector2.MoveTowards(this.transform.position, this.destinationPoint, this.horizontalSpeed * Mathf.Abs(direction) * Time.deltaTime);
        }        

    }

    private Vector2 GetRandomPointWithinRange(){
        
        float x = this.transform.position.x;
        
        while(Mathf.Abs(this.transform.position.x - x) < 10){
            x = Random.Range(minX, maxX);
        } 
        float y = this.transform.position.y;

        return new Vector2(x, y);
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
        this.destinationPoint = GetRandomPointWithinRange();
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 0){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
    }

    public void CheckIfFalling()
    {
        // Get the current position of the animal
        Vector2 position = transform.position;

        // Cast a ray downwards from the animal's position
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down);

        // If the raycast hit something
        if (hit.collider != null)
        {
            // Check if the hit object is on the "Default" or "Walls" layer
            if (hit.collider.gameObject.layer == 0 ||
                hit.collider.gameObject.layer == 6 || 
                hit.collider.gameObject.layer == 3)
            {
                // Animal is not falling
                isFalling = false;
            }
            else
            {
                // Animal is falling
                isFalling = true;
                StartCoroutine(WaitAndSetRandomDestination(2f));
            }
        }
        else
        {
            // Animal is falling
            isFalling = true;
            StartCoroutine(WaitAndSetRandomDestination(2f));
        }
    }
}
