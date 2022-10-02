using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject player;
    public float radius;
    public float cooldown;
    public GameObject playspace;
    // Update is called once per frame
    void Start(){
        Instantiate(playspace,Vector3.zero,Quaternion.identity);
        StartCoroutine("SpawnEnemy");
    }
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
    
        Vector2 point = (Vector2)player.transform.position + Random.insideUnitCircle.normalized*radius;
        GameObject temp = MasterObjectPooler.Instance.GetObject("Enemy");
        EnemyMove enemyMove = temp.GetComponent<EnemyMove>();
        enemyMove.target = player;
        temp.transform.position = point;

        yield return new WaitForSeconds(cooldown);
        StartCoroutine("SpawnEnemy");

    }

   

}
