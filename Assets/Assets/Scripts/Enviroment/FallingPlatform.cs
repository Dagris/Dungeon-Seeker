using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay;
    public Animator fallFx;

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.tag == "Player")
        {
            Debug.Log("funciona?");
            StartCoroutine(FallAfterDelay());
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FallAfterDelay());
        }

    }

    IEnumerator FallAfterDelay()
    {
        fallFx.Play("GoodFalling");
        /* fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");
         fallFx.Play("FallingPlatform");*/
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

}
