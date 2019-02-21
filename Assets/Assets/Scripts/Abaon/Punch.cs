using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    GameObject player;
    private Animator punchAnim;

    // Start is called before the first frame update
    void Start()
    {
   
        punchAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PunchIn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
           // StartCoroutine(player.GetComponent<PlayerController>().Damage());
            Debug.Log("TOMA HOSTIA");
        }
        
    }

    void PunchIn()
    {
        punchAnim.SetTrigger("Punch");
    }


}
