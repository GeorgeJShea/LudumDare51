using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    // Start is called before the first frame update
    public float offsetX;
    public float offsetY;
    public float cooldown;
    private float cooldownMax;
    public float projDelay;
    public Entity owner;
    private List<Transform> enemies = new List<Transform>();
    void Awake(){
        transform.position = transform.parent.position + new Vector3(offsetX,offsetY,0);
        cooldownMax = cooldown + offsetX + offsetY;
        cooldown = cooldownMax;
    }

    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;
        if(cooldown<0){
            if(enemies != null ){
                if(enemies.Count >0){ 
                    Shoot();
                }
            }
        } 
    }

    void Shoot(){
        cooldown = cooldownMax;
        Transform currentTarget = GetClosestEnemy(enemies);
        for(int i = owner.projCount+1;i >0;i--){
            Fireball f = GameAssets.i.Fireball.GetComponent("Fireball") as Fireball;
            f.setTarget(currentTarget);
            Instantiate(f,transform.position,Quaternion.identity);
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){

        
        if(other.tag == "Enemy"){
            
            enemies.Add(other.transform);
            
        }

    }

    void OnTriggerExit2D(Collider2D other){

        if(other.tag == "Enemy"){
            enemies.Remove(other.transform);
        }
    }

    Transform GetClosestEnemy (List<Transform> enemies)
         {
             Transform bestTarget = null;
             float closestDistanceSqr = Mathf.Infinity;
             Vector3 currentPosition = transform.position;
             foreach(Transform potentialTarget in enemies)
             {
                 Vector3 directionToTarget = potentialTarget.position - currentPosition;
                 float dSqrToTarget = directionToTarget.sqrMagnitude;
                 if(dSqrToTarget < closestDistanceSqr)
                 {
                     closestDistanceSqr = dSqrToTarget;
                     bestTarget = potentialTarget;
                 }
             }             
             return bestTarget;
         }
}
