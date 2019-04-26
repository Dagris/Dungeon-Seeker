using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAIMTEST : MonoBehaviour
{

    public Transform armL;
    public Vector3 offset;
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        armL.LookAt(test.transform.position);
        armL.rotation = armL.rotation * Quaternion.Euler(offset);
    }
}
