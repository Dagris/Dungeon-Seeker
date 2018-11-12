using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	public float distance = 5.0f;
	public ParticleSystem blinFX;

	public float coolDown = 3;
    public float coolDownTimer;
	
	// Update is called once per frame
	void Update ()
	{
		if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

		if(Input.GetKeyDown(KeyCode.LeftShift) && coolDownTimer == 0)	
		{
			BlinkF();
			blinFX.Play();

            coolDownTimer = coolDown;
        }
	}

	public void BlinkF()
	{
		RaycastHit hit;
		Vector3 destination = transform.position + transform.forward * distance;

		if(Physics.Linecast(transform.position , destination, out hit))
		{
			destination = transform.position + transform.forward * (hit.distance - 1f);
		}

		if(Physics.Raycast(destination, -Vector3.up, out hit))
		{
			destination = hit.point;
			destination.y = 0.5f;
			transform.position = destination;
		}
	}
}
