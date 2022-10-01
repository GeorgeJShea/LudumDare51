using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector2 direction; 
    private float active_time;
    private Rigidbody2D bullet;


    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        active_time=0;
        bullet.velocity = direction*speed;
    }

    // call this after every projectile is created
    public void init(int damage, float speed, Vector2 dir, float active_time, string team){
        this.damage = damage;
        this.speed = speed;
        this.direction = dir;
        this.active_time = active_time;
        gameObject.tag = team;
    }

    // prevents the bullet from existing forever
    // any extra bullet movement things will go in here
    void Update()
    {
        if(active_time<=0)
        {
            Destroy(gameObject);
        }
        active_time-=Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 
        if(col.gameObject.tag != gameObject.tag)
        {
            Entity ent = gameObject.GetComponent<Entity>(); 
            if(ent != null)
            {
                ent.currentHealth-=damage;
            }
            Destroy(gameObject);
        }
    }
}
