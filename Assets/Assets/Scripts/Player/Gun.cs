using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float shootSpeed;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    public AudioSource shotFx;
    

    private float nextTimeToFire = 0f;

    public static bool canSpecial = false;

    List<GameObject> bulletPool;
    List<GameObject> specialBulletPool;

    // Use this for initialization
    void Start ()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject projectile = (GameObject)Instantiate(bullet);
            projectile.SetActive(false);
            bulletPool.Add(projectile);
        }

       
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && PauseMenu.GameIsPaused == false)
        {
            nextTimeToFire = Time.time + fireRate;
            Fire();
        }

        
    }

    void Fire ()
    {
        shotFx.pitch = (Random.Range(0.8f, 1.8f));
        shotFx.Play();
       
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].transform.position = bulletSpawn.position;
                bulletPool[i].transform.rotation = bulletSpawn.rotation;
                bulletPool[i].SetActive(true);
                
                Rigidbody rb = bulletPool[i].GetComponent<Rigidbody>();
                rb.velocity = transform.forward * shootSpeed;

                break;
            }

           
        }

        /*GameObject projectile = Instantiate(bullet) as GameObject;
        projectile.transform.position = bulletSpawn.transform.position;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * shootSpeed;
        Destroy(projectile, 1.0f);
        */
    }

   
}
