using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicBullet : MonoBehaviour {

    public GameObject playerHit;

    void Start()
    {
        playerHit = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 1.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
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
           StartCoroutine (playerHit.GetComponent<PlayerController>().Damage());
            Debug.Log("tas jodio");
            Invoke("hideBullet", 0.1f);

        }


        
    }

}
