using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour {

	public float distance;
	public ParticleSystem blinFX;

	public float coolDown = 3;
    public float coolDownTimer;
    bool godMode;

    public Image imageCooldown;
    public float imageCD;
    public bool dashed = false;
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
            dashed = true;
            coolDownTimer = coolDown;
        }

        if(dashed)
        {
            imageCooldown.fillAmount += 1 / imageCD * Time.deltaTime;

            if(imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                dashed = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            godMode = !godMode;
            GodMode();
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

    void GodMode()
    {
        if (godMode == true)
        {
            coolDown = 0;

        }

        if (godMode == false)
        {
            coolDown = 3;
        }
    }
}
