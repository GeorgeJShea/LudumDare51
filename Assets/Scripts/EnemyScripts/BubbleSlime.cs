using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSlime : Entity
{
    public int scoreValue;
    Rigidbody2D rb;
    protected float timeBetweenShots = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        moveAllowed = true;
    }
    void OnCollisionEnter2D(Collision2D other){

        
        if(other.collider.tag == "Player"){
            other.gameObject.GetComponent<Entity>().currentHealth-=1;
        }

    }

    void Update(){

        if(currentHealth <= 0){
            Player.score += scoreValue;
            MasterObjectPooler.Instance.Release(this.gameObject, "RangedEnemy");
            currentHealth = maxHealth;
        }
        
    }

    private void FixedUpdate()
    {

        // movement
        float step = speed * Time.deltaTime * RandomEffectManager.globalGameSpeed;

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
            bullet.transform.position = transform.position;
            Vector3 dir = (target.transform.position-transform.position).normalized;
            //bullet.transform.rotation = Quaternion.LookRotation(dir);
            bullet.GetComponent<Bullet>().setDirection(dir);
        }
    }
}
