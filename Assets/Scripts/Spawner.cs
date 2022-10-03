using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public float timeBetweenSpawns;
    private float timeTillNextSpawn;
    public string enemyPool;
    public float radius;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        timeTillNextSpawn-=Time.deltaTime;
        if(timeTillNextSpawn<=0)
        {
            Debug.Log("Spawner Spawned Enemy");
            GameObject enemy = MasterObjectPooler.Instance.GetObject(enemyPool);
            enemy.transform.position = (Vector2)this.transform.position + Random.insideUnitCircle.normalized*radius;
            enemy.GetComponent<Entity>().target = player;
            timeTillNextSpawn = timeBetweenSpawns;
        }
    }
}