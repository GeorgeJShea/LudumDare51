using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float damage;
    // Update is called once per frame
    
    void OnTriggerEnter2D(Collider2D other){

        
        if(other.tag == "Enemy"){
            EnemyMove script = other.GetComponent<EnemyMove>();
            script.currentHealth -= damage;
            DamagePopup.Create(other.transform.position,damage);
        }

    }

    public void ActivateDamage(){
       GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Done(){
        Destroy(this.gameObject);
    }

    public void setDamage(float damage){
        this.damage = damage;

    }
}
