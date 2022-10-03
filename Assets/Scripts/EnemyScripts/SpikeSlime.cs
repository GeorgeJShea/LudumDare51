using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlime : Entity
{
    public int scoreValue;
    Rigidbody2D rb;
    public float timeBetweenHits;
    private float timeTillNextHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(timeTillNextHit<=0)
        {
            if(other.collider.tag == "Player"){
                other.gameObject.GetComponent<Entity>().currentHealth-=5;
                timeTillNextHit = timeBetweenHits;
            }
        }

    }

    void Update()
    {
        if(timeTillNextHit>0)timeTillNextHit-=Time.deltaTime;
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
