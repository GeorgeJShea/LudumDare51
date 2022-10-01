using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating_sword : MonoBehaviour
{
    public float offset;
    public float speed;
    public float damage;

    void Awake(){
        transform.position = transform.parent.position + new Vector3(offset,offset,0);

    }
    void Update()
    {
        transform.RotateAround(transform.parent.position,new Vector3(0,0,1), speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){

        
        if(other.tag == "Enemy"){
            EnemyMove script = other.GetComponent<EnemyMove>();
            script.currentHealth -= damage;
            DamagePopup.Create(this.transform.position,damage);
        }
        


    }
}
