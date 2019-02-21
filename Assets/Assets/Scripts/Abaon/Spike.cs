using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject player;
    Collider col;
    Collider chCol;
    private Animator spikeAnim;
    private MeshRenderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        chCol = GetComponentInChildren<MeshCollider>();
        chCol.enabled = false;
        spikeAnim = gameObject.GetComponentInChildren<Animator>();
        rend = gameObject.GetComponentInChildren<MeshRenderer>();
        rend.enabled = false;
        StartCoroutine("EnableSpike");
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(player.GetComponent<PlayerStats>().Damage());
            Debug.Log("SPIKESITO");
            

        }
        
    }

    IEnumerator EnableSpike()
    {
     
        yield return new WaitForSeconds(0.5f);
        rend.enabled = true;
        spikeAnim.Play("SpikeIn");
       
        yield return new WaitForSeconds(0.15f);
        col.enabled = true;
        chCol.enabled = true;

        yield return new WaitForSeconds(2f);
        StartCoroutine("DisableSpike");
    }

    IEnumerator DisableSpike()
    {
        spikeAnim.Play("SpikeOut");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
