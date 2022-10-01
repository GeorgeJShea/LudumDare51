using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDispenser : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldown;
    private float cooldownMax;

    public float damage;
    // Update is called once per frame
    void Awake(){
        cooldownMax = cooldown;
    }
    
    void Update()
    {

        cooldown -= Time.deltaTime;
        if(cooldown<0){
            PlaceBomb(damage);    
        } 
    }


    void PlaceBomb(float damage){
        
        Bomb b = GameAssets.i.Bomb.GetComponent("Bomb") as Bomb;
        b.setDamage(damage);
        Instantiate(b,transform.position,Quaternion.identity) ;
        cooldown = cooldownMax;
    }
}
