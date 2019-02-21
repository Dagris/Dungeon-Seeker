using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour {

	public float distance;
	public ParticleSystem blinFX;

	public float coolDown = 3;
    public float coolDownTimer;
    public bool godMode;

    float rtAxis;
    public Image imageCooldown;
    public float imageCD;
    public bool dashed = false;
    bool locked = false;

    void Start()
    {

    }
	void Update ()
	{
        if(Input.GetButtonDown("R3"))
        {
            locked = !locked;
        }

        if (locked == false)
        {
            rtAxis = Input.GetAxis("RT");
            if (coolDownTimer >= 0)
            {
                coolDownTimer -= Time.deltaTime;
            }

            if (coolDownTimer <= 0)
            {
                coolDownTimer = 0;
            }

            if (coolDownTimer == 0 && Input.GetButtonDown("RT"))
            {
                coolDownTimer = coolDown;
                BlinkF();
                blinFX.Play();
                dashed = true;

            }

            if (coolDownTimer == 0 && rtAxis == -1)
            {
                coolDownTimer = coolDown;
                BlinkF();
                blinFX.Play();
                dashed = true;
            }

            if (dashed)
            {
                if(imageCooldown != null)
                {
                    imageCooldown.fillAmount += 1 / imageCD * Time.deltaTime;

                    if (imageCooldown.fillAmount >= 1)
                    {
                        imageCooldown.fillAmount = 0;
                        dashed = false;
                    }
                }
                
            }

            if (Input.GetKeyDown(KeyCode.F10))
            {
                godMode = !godMode;
                GodMode();
            }
        }

        

    }

    public void BlinkF()
	{
		RaycastHit hit;
        Vector3 destination = transform.position + transform.forward * distance;
        Debug.DrawRay(transform.position, destination);
        if (Physics.Linecast(transform.position , destination, out hit))
		{
			destination = transform.position + transform.forward * (hit.distance - 1f);
		}

		if(Physics.Raycast(destination, -Vector3.up, out hit))
		{
			destination = hit.point;
			destination.y = transform.position.y;
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
