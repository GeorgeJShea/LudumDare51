using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] protected Vector2 direction; 
    [SerializeField] private float active_time;
    [SerializeField] private Rigidbody2D bullet;

    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = direction*speed;
    }

    // prevents the bullet from existing forever
    // any extra bullet movement things will go in here
    void Update()
    {
        if(active_time<=0)
        {
            Debug.Log("Bullet timed out");
            Destroy(gameObject);
        }
        active_time-=Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided with "+col.gameObject.name);
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
