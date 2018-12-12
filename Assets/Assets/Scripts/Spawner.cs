using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnee;
    public float spawnDelay;
    public bool stopSpawning = false;
    public float spawnTime;
    GameObject abaon;





    // Use this for initialization
    void Start () {
        

	}

    void Update ()
    {
        abaon = GameObject.FindGameObjectWithTag("Enemy");
        EnemyStats abaonHP = abaon.GetComponent<EnemyStats>();
        if (abaonHP.enemyHP <= 5)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        }
    }
	
	public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");

        }

    }
}
