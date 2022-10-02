using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] public int max_active_time = 4;
    private float active_time = 0;
    [SerializeField] private Rigidbody2D bullet;

    void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
    }
    public void setDirection(Vector2 dir)
    {
        bullet.velocity = dir*speed;
        Debug.Log(bullet.velocity);
    }
    
    void OnDisable(){
        Debug.Log("Disabled");
    }
    // prevents the bullet from existing forever
    // any extra bullet movement things will go in here
    void Update()
    {
        if(active_time>=max_active_time)
        {
            Debug.Log("Bullet timed out");
            active_time = 0;
            MasterObjectPooler.Instance.Release(this.gameObject, "Bullet");
        }
        active_time+=Time.deltaTime;
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
