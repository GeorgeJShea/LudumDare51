using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject player;
    public float radius;
    public float cooldown;
    // Update is called once per frame
    void Start(){
        StartCoroutine("SpawnEnemy");
    }
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
    
        Vector2 point = (Vector2)player.transform.position + Random.insideUnitCircle.normalized*radius;
        GameObject temp;
        if(Random.value<.6)
        {
            temp = MasterObjectPooler.Instance.GetPool("MeleeEnemy").GetObject();
        }else{
            temp = MasterObjectPooler.Instance.GetPool("RangedEnemy").GetObject();
        }
        Entity enemyMove = temp.GetComponent<Entity>();
        enemyMove.target = player;
        temp.transform.position = point;

        yield return new WaitForSeconds(cooldown);
        StartCoroutine("SpawnEnemy");

    }

   

}
