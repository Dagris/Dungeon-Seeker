using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAreaBullet : MonoBehaviour
{
    public GameObject playerHit;
    Collider col;
    public ParticleSystem bulletFX;
    public ParticleSystem bulletColFX;
    public ParticleSystem sandTrail;

    void Start()
    {
        playerHit = GameObject.FindGameObjectWithTag("Player");
        col = gameObject.GetComponent<Collider>();
        
       // col.enabled = false;
    }
    private void OnEnable()
    {
        
        bulletFX.gameObject.SetActive(true);
        Invoke("EnableCol", 0.2f);
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 4f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    void EnableCol()
    {
        col.enabled = true;
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(playerHit.GetComponent<PlayerStats>().Damage());
            Debug.Log("tas jodio");
            bulletFX.gameObject.SetActive(false);
            col.enabled = false;
            sandTrail.Stop();
            bulletColFX.Play();
            Invoke("hideBullet", 1.5f);

        }

        else if(collision.gameObject.tag == "Wall")
        {
            bulletFX.gameObject.SetActive(false);
            col.enabled = false;
            sandTrail.Stop();
            bulletColFX.Play();
            Invoke("hideBullet", 1.5f);
        }



    }
}
