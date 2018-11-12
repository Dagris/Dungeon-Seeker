using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float shootSpeed;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    private float nextTimeToFire = 0f;

    List<GameObject> bulletPool;

	// Use this for initialization
	void Start ()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject projectile = (GameObject)Instantiate(bullet);
            projectile.SetActive(false);
            bulletPool.Add(projectile);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Fire();
        }
	}

    void Fire ()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].transform.position = transform.position;
                bulletPool[i].transform.rotation = transform.rotation;
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
