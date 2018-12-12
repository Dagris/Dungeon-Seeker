using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betlee : MonoBehaviour
{

    public GameObject Player;
    Transform playerPos;
    public float movementSpeed = 4;
    public ParticleSystem blood;

    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerPos = Player.transform;
    }
    void Update()
    {
        Vector3 rotation = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);
        
        transform.LookAt(rotation);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnEnable()
    {
       transform.GetComponent<Rigidbody>().WakeUp();
       Invoke("hideBetlee", 15f);
    }

    void hideBetlee()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        CancelInvoke();
    }

      void OnTriggerEnter(Collider other)
    {
        Debug.Log("no hitea");

        if (other.gameObject.tag == "Player")
        {
            blood.Play();
            StartCoroutine(Player.GetComponent<PlayerController>().Damage());
            Debug.Log("betlee");
            Invoke("hideBetlee", 0.1f);

        }

        if (other.gameObject.tag == "PlayerBullet")
        {
            blood.Play();
            
            Debug.Log("betlee");
            Invoke("hideBetlee", 0.1f);

        }
    }

}