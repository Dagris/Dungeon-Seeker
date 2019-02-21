using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetleeSpawner : MonoBehaviour {

    public GameObject Betlee;
    GameObject abaon;
    bool isSpawning = false;

    List<GameObject> betleetPool;

    void Start()
    {
       
        betleetPool = new List<GameObject>();
        for (int i = 0; i < 1; i++)
        {
            GameObject projectile = (GameObject)Instantiate(Betlee);
            projectile.SetActive(false);
            betleetPool.Add(projectile);
        }

    }



    void Update ()

    {
        abaon = GameObject.FindGameObjectWithTag("Enemy");
        EnemyStats abaonHP = abaon.GetComponent<EnemyStats>();
        if (abaonHP.enemyHP <= 5 && !isSpawning)
        {
            StartCoroutine("Spawning");
        }
    }


    IEnumerator Spawning()
    {
        isSpawning = true;
        while (true)
        {
            for (int i = 0; i < betleetPool.Count; i++)
            {
                if (!betleetPool[i].activeInHierarchy)
                {
                    betleetPool[i].transform.position = transform.position;
                    betleetPool[i].transform.rotation = transform.rotation;
                    betleetPool[i].SetActive(true);

                    // Rigidbody enemyrb = betleetPool[i].GetComponent<Rigidbody>();

                    //yield return new WaitForSeconds(5);
                    break;
                }
            }
            yield return new WaitForSeconds(8);

        }

    }
}
