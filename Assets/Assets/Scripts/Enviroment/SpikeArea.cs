using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeArea : MonoBehaviour
{
    [Header("Spike")]
    GameObject player;
    public GameObject spike;
    Vector3 playerPos;
    Vector3 spikePos;

    public float spikeCoolDown = 10;
    float coolDownTimer;

    public bool entered = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coolDownTimer = 10;
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

        if (coolDownTimer == 0 && entered == true)
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

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
       {
            entered = true;
       }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = false;
        }

    }
}
