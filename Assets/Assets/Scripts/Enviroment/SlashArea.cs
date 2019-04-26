using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashArea : MonoBehaviour
{
    public GameObject enemySandBullet;
    public float shootSpeed;
    public float waitFor;
    public ParticleSystem warning;
    public AudioSource prev;

    List<GameObject> enemyBulletPool;


    void Start()
    {
        enemyBulletPool = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject projectile = (GameObject)Instantiate(enemySandBullet);
            projectile.SetActive(false);
            enemyBulletPool.Add(projectile);
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
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
            yield return new WaitForSeconds(waitFor);

            for (int i = 0; i < enemyBulletPool.Count; i++)
            {
                if (!enemyBulletPool[i].activeInHierarchy)
                {
                    warning.Play();
                    prev.pitch = (Random.Range(0.8f, 1.8f));
                    prev.Play();
                    yield return new WaitForSeconds(0.5f);
                    enemyBulletPool[i].transform.position = transform.position;
                    enemyBulletPool[i].transform.rotation = transform.rotation;
                    enemyBulletPool[i].SetActive(true);

                    
                    Rigidbody enemyrb = enemyBulletPool[i].GetComponent<Rigidbody>();
                    enemyrb.velocity = transform.forward * shootSpeed;
                    yield return new WaitForSeconds(1);
                    break;
                }
            }
            

        }

    }
}
