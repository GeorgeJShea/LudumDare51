using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlime : Entity
{
    public int scoreValue;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionEnter2D(Collision2D other){

        
        if(other.collider.tag == "Player"){
            other.gameObject.GetComponent<Entity>().currentHealth-=5;
        }

    }

    void Update(){

        if(currentHealth <= 0){
            Player.score += scoreValue;
            MasterObjectPooler.Instance.Release(this.gameObject, "MeleeEnemy");
            currentHealth = maxHealth;
        }
        
    }

    private void FixedUpdate()
    {
        // movement
        float step = speed * Time.deltaTime * RandomEffectManager.globalGameSpeed;
        if (moveAllowed)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, step));
        }

        // flips the sprite to face the target
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