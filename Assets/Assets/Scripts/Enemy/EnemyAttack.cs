using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public Transform player;
    public float playerDistance;

    public float playerLook;
    //public float playerChase;

    public float rotationSmooth;

   /* public float chaseStartRange;
    public float moveSpeed;
    */
	public GameObject enemySandBullet;
	public float shootSpeed;
    

	List<GameObject> enemyBulletPool;

	void Awake () 
	{
		 
	}

	void Start ()
    {
        enemyBulletPool = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject projectile = (GameObject)Instantiate(enemySandBullet);
            projectile.SetActive(false);
            enemyBulletPool.Add(projectile);
        }
	}
	
	
	void Update () 
	{
        playerDistance = Vector3.Distance(player.position, transform.position);

        if(playerDistance < playerLook)
        {
            lookAtPlayer();
        }

      /*  if(playerDistance < playerChase)
        {
            Chase();
        }
        */
	}


    void lookAtPlayer ()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSmooth);
    }


   /* void Chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Debug.Log("stalker");
    }
    */

	


	/* IEnumerator Shooting()
	{
		while (true)
		{
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
		}
	}
    */
}
