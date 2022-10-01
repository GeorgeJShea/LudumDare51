using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public Transform target;
    public float damage;

    public float speed;
    public float disappearTimer;
    private Vector2 dir;

    // Update is called once per frame
    void Awake(){
        dir = (this.transform.position - target.transform.position).normalized;

    }
    void FixedUpdate()
    {
        
        float step = speed * Time.deltaTime;
         
        
        // move sprite towards the target direction
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position-dir, step);
        

        disappearTimer -= Time.deltaTime;
        if(disappearTimer<0){
            Destroy(this.gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D other){

        
        if(other.tag == "Enemy"){
            EnemyMove script = other.GetComponent<EnemyMove>();
            script.currentHealth -= damage;
            DamagePopup.Create(other.transform.position,damage);
            Destroy(this.gameObject);
        }

    }

    public void setTarget(Transform target){

        this.target = target;

    }



}
