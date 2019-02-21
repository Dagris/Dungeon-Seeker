using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    [Header("Spike")]
    GameObject player;
    public GameObject spike;
    Vector3 playerPos;
    Vector3 spikePos;

    public float spikeCoolDown = 10;
    float coolDownTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolDownTimer =10;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        if (coolDownTimer >= 0)
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

    }

    void Spiking()
    {
        Vector3 spikePos = new Vector3(playerPos.x, transform.position.y, playerPos.z);
        Instantiate(spike, spikePos, Quaternion.identity);
    }


   /* private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(playerPos.GetComponent<PlayerController>().Damage());
            Debug.Log("SPIKESITO");

            

            StartCoroutine("Spiked");

        }

    }

    */
}
