using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector2 direction; 
    private float time_active;
    private Rigidbody2D bullet;
    public int team;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        time_active=0;
        bullet.velocity = direction*speed;
    }

    // prevents the bullet from existing forever
    void Update()
    {
        if(time_active>=5)
        {
            Destroy(gameObject);
        }
        time_active+=Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // need to see how player/enemy/walls are implemented before coninuing
        // this will be where damage is applied
        // it would be cool if player and enemy bullets collided and destroyed eachother
    }
}
