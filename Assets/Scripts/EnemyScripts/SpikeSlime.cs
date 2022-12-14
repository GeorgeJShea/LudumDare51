using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlime : Entity
{
    public GameObject deathAffect;
    public int scoreValue;
    Rigidbody2D rb;

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
            target.GetComponent<Player>().score += scoreValue;
            if(gameObject.name.Contains("BossSlime")) Destroy(gameObject);
            MasterObjectPooler.Instance.Release(this.gameObject, "MeleeEnemy");
            currentHealth = maxHealth;
            Instantiate(deathAffect, gameObject.transform.position, Quaternion.identity);
        }
        
    }

    private void FixedUpdate()
    {
        // movement
        float step = speed * Time.deltaTime * Level_Manager.instance.globalGameSpeed;
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
