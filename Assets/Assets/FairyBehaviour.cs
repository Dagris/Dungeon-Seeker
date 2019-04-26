using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FairyBehaviour : MonoBehaviour
{
    public Transform playerSpot;
    public float followSpeed;
    public Animator flameAnim;
    public bool isIdle;
    public float idleTimer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        flameAnim.SetBool("isIdle", isIdle);
        flameAnim.SetFloat("idleTimer", idleTimer);
        transform.position = Vector3.Lerp(transform.position, playerSpot.position, Time.deltaTime * followSpeed);

        StartCoroutine("CalcSpeed");

        if(isIdle)
        {
            idleTimer++;
        }

        else
        {
            idleTimer = 0;
        }
    }

     IEnumerator CalcSpeed()
    {
        var prevPos = transform.position.x;
        yield return new WaitForSeconds(0.5f);
        var actualPos = transform.position.x;

        if (prevPos == actualPos)
        {
            print("character stoped");
            isIdle = true;
        }

        if (prevPos != actualPos)
        {
            print("character on the move");
            isIdle = false;
        }

    }
}
