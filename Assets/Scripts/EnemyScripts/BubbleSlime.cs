using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSlime : Entity
{
    public GameObject deathAffect;
    public int scoreValue;
    Rigidbody2D rb;
    protected float timeBetweenShots = 1;
    public int healthSteal = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(timeTillNextHit<=0)
        {
            if(other.collider.tag == "Player"){
                other.gameObject.GetComponent<Entity>().currentHealth-=2;
                timeTillNextHit = timeBetweenHits;
            }
        }
    }

    void Update(){

        if(currentHealth <= 0){
            target.GetComponent<Player>().score += scoreValue;
            if(target.GetComponent<Player>().currentHealth < 100 + healthSteal)
                target.GetComponent<Player>().currentHealth += healthSteal;
            MasterObjectPooler.Instance.Release(this.gameObject, "RangedEnemy");
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
            float distanceToTarget = (target.transform.position-transform.position).magnitude;
            if(distanceToTarget>5)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, step));
            }
            else if(distanceToTarget<4)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, -step));
            }
            
        }

        // makes sure the sprite is facing the target
        if (target.transform.position.x > transform.position.x)
        {
            
            transform.localScale = originalScale;
        }
        else
        {
            transform.localScale = new Vector3(0 - originalScale.x, originalScale.y, originalScale.z);
        }
        timeBetweenShots-=Time.deltaTime;
        //shoot projectile at target
        if(timeBetweenShots<=0)
        {
            Debug.Log("Shot a bullet");
            timeBetweenShots = 1;
            GameObject bullet = MasterObjectPooler.Instance.GetPool("Bullet").GetObject();
            bullet.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
            bullet.transform.position = transform.position;
            Vector3 dir = (target.transform.position-transform.position).normalized;
            bullet.GetComponent<Bullet>().setDirection(dir);
        }
    }
}
