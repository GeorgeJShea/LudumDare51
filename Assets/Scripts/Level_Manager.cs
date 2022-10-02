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
        GameObject temp = MasterObjectPooler.Instance.GetPool("MeleeEnemy").GetObject();
        EnemyMove enemyMove = temp.GetComponent<EnemyMove>();
        enemyMove.target = player;
        temp.transform.position = point;

        yield return new WaitForSeconds(cooldown);
        StartCoroutine("SpawnEnemy");

    }

   

}
