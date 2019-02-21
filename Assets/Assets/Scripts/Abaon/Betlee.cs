using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betlee : MonoBehaviour
{
    public GameObject PlayerTarget;
    public GameObject Player;
    Transform playerPos;
    public float movementSpeed = 4;
    public ParticleSystem blood;

    public bool startfollow = false;

    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("PTarget");
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = PlayerTarget.transform;
    }
    void Update()
    {
        if(startfollow)
        {
            Vector3 rotation = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);

            transform.LookAt(rotation);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

        }
 
    }

   /* private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBetlee", 15f);
    }
    */
    void hideBetlee()
    {
        gameObject.SetActive(false);
    }
    /*
    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        CancelInvoke();
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("no hitea");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER HITTED");
            //blood.Play();
            StartCoroutine(Player.GetComponent<PlayerStats>().Damage());
            //Debug.Log("betlee");
            Invoke("hideBetlee", 0.1f);

        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            //blood.Play();

            Debug.Log("betlee");
            Invoke("hideBetlee", 0.1f);

        }
    }

    void Follow()
    {
        Vector3 rotation = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);

        transform.LookAt(rotation);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            startfollow = true;
        }
    }
}
