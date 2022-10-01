using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Entity
{
    
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionEnter2D(Collision2D other){

        
        if(other.collider.tag == "Player"){
            moveAllowed = false;
        }
        


    }

    void Update(){

        if(currentHealth <0){
            Destroy(this.gameObject);
        }

    }
    void OnCollisionExit2D(Collision2D other){

        if(other.collider.tag == "Player"){
            moveAllowed = true;
        }


    }

    void FixedUpdate()
    {
        

        float step = speed * Time.deltaTime;

        float currentDistance = Vector2.Distance(transform.position,target.transform.position);
        // move sprite towards the target location
        if(moveAllowed){
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        }

        if(target.transform.position.x > transform.position.x){
            transform.localScale = new Vector3(0 - originalScale.x,originalScale.y,originalScale.z);
        }else{
            transform.localScale = originalScale;
        }


    }

    
}
