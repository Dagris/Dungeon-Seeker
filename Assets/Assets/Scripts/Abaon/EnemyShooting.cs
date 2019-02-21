using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	
    public GameObject enemySandBullet;
	public float shootSpeed;
    

	List<GameObject> enemyBulletPool;


	void Start ()
    {
        enemyBulletPool = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject projectile = (GameObject)Instantiate(enemySandBullet);
            projectile.SetActive(false);
            enemyBulletPool.Add(projectile);
        }
	}
	
	

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("Shooting");
        }
    }

  
	IEnumerator Shooting()
	{
		while (true)
		{
           yield return new WaitForSeconds(1);

            for (int i = 0; i < enemyBulletPool.Count; i++)
            {
                 if (!enemyBulletPool[i].activeInHierarchy)
                {
                    enemyBulletPool[i].transform.position = transform.position;
                    enemyBulletPool[i].transform.rotation = transform.rotation;
                    enemyBulletPool[i].SetActive(true);

                   
                    Rigidbody enemyrb = enemyBulletPool[i].GetComponent<Rigidbody>();
                     enemyrb.velocity = transform.forward * shootSpeed;

                    break;
                   }
            }
            yield return new WaitForSeconds(4);
           
		}
        
	}
     
}
