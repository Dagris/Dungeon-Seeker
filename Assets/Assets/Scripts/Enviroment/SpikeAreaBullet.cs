using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAreaBullet : MonoBehaviour
{
    public GameObject playerHit;
    Collider col;

    void Start()
    {
        playerHit = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<Collider>();
       // col.enabled = false;
    }
    private void OnEnable()
    {
        //Invoke("EnableCol", 0.2f);
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 0.5f);
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
            Invoke("hideBullet", 0.1f);

        }



    }
}
