using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaonBehaviour : MonoBehaviour
{
    [Header ("Slash Vertical")]
    public GameObject enemySandBullet;
    public float shootSpeed;
    public GameObject v1;
    public GameObject v2;
    public GameObject v3;
    List<GameObject> enemyBulletPool;

    [Header ("Slash Horizontal")]
    public GameObject HenemySandBullet;
    public float HshootSpeed;
    public GameObject h1;
    List<GameObject> HenemyBulletPool;

    [Header("Spike")]
    public GameObject spike;
    GameObject player;
    Vector3 playerPos;
    Vector3 spikePos;
    //public float spikeCoolDown = 10;
    //float coolDownTimer;

    [Header("Swarm")]
    public GameObject swarm;
    public GameObject swarmPoint;
    List<GameObject> betleetPool;

    [Header("Animations")]
    public Animator abaonAnim;
    public int abaonLogic;
    //public bool hasAttacked = false;
    //public float CoolDown = 2;
    //float coolDownTimer;

    void Start()
    {
        //Slash Vertical
        enemyBulletPool = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            GameObject projectile = (GameObject)Instantiate(enemySandBullet);
            projectile.SetActive(false);
            enemyBulletPool.Add(projectile);
        }

        //Slash Horizontal
        HenemyBulletPool = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject Hprojectile = (GameObject)Instantiate(HenemySandBullet);
            Hprojectile.SetActive(false);
            HenemyBulletPool.Add(Hprojectile);
        }

        //Spike
        player = GameObject.FindGameObjectWithTag("Player");
        //coolDownTimer = 10;

        //Swarm
        betleetPool = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject swarmP = (GameObject)Instantiate(swarm);
            swarmP.SetActive(false);
            betleetPool.Add(swarmP);
        }

        Invoke("AbaonLogicAtks", 1);
    }


    private void Update()
    {
        //SPIKE
        playerPos = player.transform.position;

        /* if (coolDownTimer >= 0)
         {
             coolDownTimer -= Time.deltaTime;
         }

         if (coolDownTimer <= 0)
         {
             coolDownTimer = 0;
         }

         if (coolDownTimer == 0)
         {
             Spiking();
             coolDownTimer = spikeCoolDown;
         }
         */

        //SWARM

        //TRIGGER TEST
        if(Input.GetKeyDown(KeyCode.V))
        {
            abaonAnim.SetTrigger("VSlash");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            abaonAnim.SetTrigger("HSlash");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            abaonAnim.SetTrigger("Swarm");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            abaonAnim.SetTrigger("Spike");
        }
        //RANDOM ATTACKS OF ABAON

        //Invoke("AbaonLogicAtks", 2);

        /*if (coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0)
        {
            coolDownTimer = 0;
        }

        if (coolDownTimer == 0)
        {
            AbaonLogicAtks();
            coolDownTimer = CoolDown;
            hasAttacked = true;
        }
        */
     
    
     
    }

    public void SlashV()
    {
        Debug.Log("SLASH VERTICAL DONE");

        for (int i = 0; i < enemyBulletPool.Count; i++)
        {
            if (!enemyBulletPool[i].activeInHierarchy)
            {
                enemyBulletPool[i].transform.position = v1.transform.position;
                enemyBulletPool[i].transform.rotation = transform.rotation;
                enemyBulletPool[i].SetActive(true);


                Rigidbody enemyrb = enemyBulletPool[i].GetComponent<Rigidbody>();
                enemyrb.velocity = transform.forward * shootSpeed;


                break;
            }

        }

       
    }

    public void SlashH()
    {
        Debug.Log("SLASH HORIZONTAL DONE");

        for (int i = 0; i < HenemyBulletPool.Count; i++)
        {
            if (!HenemyBulletPool[i].activeInHierarchy)
            {
                HenemyBulletPool[i].transform.position = h1.transform.position;
                HenemyBulletPool[i].transform.rotation = transform.rotation;
                HenemyBulletPool[i].SetActive(true);


                Rigidbody Henemyrb = HenemyBulletPool[i].GetComponent<Rigidbody>();
                Henemyrb.velocity = transform.forward * HshootSpeed;
                
                break;
            }

        }
    }

    public void Spike()
    {
        Vector3 spikePos = new Vector3(playerPos.x, transform.position.y, playerPos.z);
        Instantiate(spike, spikePos, Quaternion.identity);
    }

    public void Swarm()
    {
        Debug.Log("SWARM DONE");
        for (int i = 0; i < betleetPool.Count; i++)
        {
            if (!betleetPool[i].activeInHierarchy)
            {
                betleetPool[i].transform.position = swarmPoint.transform.position;
                betleetPool[i].transform.rotation = transform.rotation;
                betleetPool[i].SetActive(true);

                // Rigidbody enemyrb = betleetPool[i].GetComponent<Rigidbody>();

                break;
            }
        }
    }
/*
    IEnumerator AbaonLogiAtks()
    {
        yield return new WaitForSeconds(2);
        abaonLogic = Random.Range(1, 10);
        
    }
    */

    void AbaonLogicAtks()
    {
        abaonLogic = Random.Range(1, 10);

        if (abaonLogic == 1 || abaonLogic == 2 || abaonLogic == 3)
        {
            abaonAnim.SetTrigger("VSlash");

        }

        if (abaonLogic == 4 || abaonLogic == 5)
        {
            abaonAnim.SetTrigger("HSlash");

        }

        if (abaonLogic == 6 || abaonLogic == 7)
        {
            abaonAnim.SetTrigger("Swarm");

        }

        if (abaonLogic == 8 || abaonLogic == 9 || abaonLogic == 10)
        {
            abaonAnim.SetTrigger("Spike");

        }

        Invoke("AbaonLogicAtks", 2);
    }
}

