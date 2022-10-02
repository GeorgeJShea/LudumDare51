using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;

public class Level_Manager2 : MonoBehaviour
{
    public GameObject player;
    public MasterObjectPooler mop;
    [SerializeField] public GameObject enemy_prefab;
    [SerializeField] public GameObject bullet_prefab;
    public float radius;
    public float cooldown;

    // Update is called once per frame
    void Start(){
        mop = MasterObjectPooler.Instance;
        mop.AddPool("enemy bullets",ObjectPool.Create(bullet_prefab,100,150));
        enemy_prefab.GetComponent<EnemyMove>().target = player;
        mop.AddPool("enemies",ObjectPool.Create(enemy_prefab,10,20));
        StartCoroutine("SpawnEnemy");
    }
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
    

    Vector2 point = (Vector2)player.transform.position + Random.insideUnitCircle.normalized*radius;
    GameObject temp = mop["enemies"].GetObject((Vector3)point);
    EnemyMove enemyMove = temp.GetComponent<EnemyMove>();
    
    temp.transform.position = point;
    Debug.Log("Spawned a new enemy");
    yield return new WaitForSeconds(cooldown);
    StartCoroutine("SpawnEnemy");

    }

   

}
