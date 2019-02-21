using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f;
    public Animator fallFx;

    void OnCollisionEnter(Collision collidedWithThis)
    {
        if (collidedWithThis.gameObject.name == "Player")
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        fallFx.Play("FallingPlatform");
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
    }
}
