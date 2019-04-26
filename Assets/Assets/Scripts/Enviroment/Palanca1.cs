using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca1 : MonoBehaviour
{
    public Animator palancAnim;
    public Animator door;
    public float ltAxis;
    public Camera gameCamera;
    public Camera d1Camera;
    bool activated;

    public AudioSource solved;

    void Start()
    {
        palancAnim = GetComponent<Animator>();
        gameCamera.gameObject.SetActive(true);
        d1Camera.gameObject.SetActive(false);
        activated = false;
    }

    void Update()
    {
        ltAxis = Input.GetAxis("Action");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" & activated == false)
        {
            if (Input.GetButtonDown("Action"))
            {
                palancAnim.SetTrigger("switch");
                //door.gameObject.SetActive(false);
                StartCoroutine("PalancaCine");
                activated = true;
            }

            if (ltAxis == -1)
            {
                palancAnim.SetTrigger("switch");
                //door.gameObject.SetActive(false);
                StartCoroutine("PalancaCine");
                activated = true;
            }
        }
    }

    IEnumerator PalancaCine()
    {
        
        yield return new WaitForSeconds(1);
        gameCamera.gameObject.SetActive(false);
        d1Camera.gameObject.SetActive(true);
        //palancAnim.SetTrigger("d1");
        yield return new WaitForSeconds(0.5f);
        door.Play("DOOR1");
        yield return new WaitForSeconds(1f);
        solved.Play();
        yield return new WaitForSeconds(3);
        d1Camera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);
    }
}
