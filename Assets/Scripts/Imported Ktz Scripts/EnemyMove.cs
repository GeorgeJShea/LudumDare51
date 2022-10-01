using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Entity
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionEnter2D(Collision2D other){

        
        if(other.collider.tag == "Player"){

        }
        


    }

    void Update(){

        if(currentHealth <0){
            Destroy(this.gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        if (moveAllowed)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, step));
        }

        if (target.transform.position.x > transform.position.x)
        {
            
            transform.localScale = originalScale;
        }
        else
        {
            transform.localScale = new Vector3(0 - originalScale.x, originalScale.y, originalScale.z);
        }

    }
}
