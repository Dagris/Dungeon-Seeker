using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaonPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SpecialGun.canSpecial = true;
            gameObject.SetActive(false);
        }
        
    }
}
