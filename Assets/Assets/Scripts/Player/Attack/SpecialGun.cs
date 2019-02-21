using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialGun : MonoBehaviour {

    public GameObject specialBullet;
    public float shootSpeed;
    public Transform bulletSpawn;
    public float fireRate = 2;


    private float nextTimeToFire = 0f;

    public static bool canSpecial = false;

    public Image imageCooldown;
    public Image specialImage;
    public float imageCD = 2;
    public bool specialShooted = false;


    List<GameObject> specialBulletPool;
    // Use this for initialization
    void Start ()
    {
        specialBulletPool = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            GameObject projectile = (GameObject)Instantiate(specialBullet);
            projectile.SetActive(false);
            specialBulletPool.Add(projectile);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if (Input.GetButtonDown("B") && canSpecial && Time.time >= nextTimeToFire && PauseMenu.GameIsPaused == false)
        {
            specialShooted = true;
            nextTimeToFire = Time.time + fireRate;
            Debug.Log("special");
            FireSpecial();
        }

        if (specialShooted)
        {
            imageCooldown.fillAmount += 1 / imageCD * Time.deltaTime;

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                specialShooted = false;
            }
        }
    }

    void FireSpecial()
    {
        for (int i = 0; i < specialBulletPool.Count; i++)
        {
            if (!specialBulletPool[i].activeInHierarchy)
            {
                specialBulletPool[i].transform.position = bulletSpawn.position;
                specialBulletPool[i].transform.rotation = bulletSpawn.rotation;
                specialBulletPool[i].SetActive(true);

                Rigidbody rb = specialBulletPool[i].GetComponent<Rigidbody>();
                rb.velocity = transform.forward * shootSpeed;

                break;
            }


        }
    }
}
