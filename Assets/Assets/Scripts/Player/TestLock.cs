using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLock : MonoBehaviour
{    
    public Transform target;
    public Transform player;

    public Vector3 forwardDir;

    public CharacterController controller;
    public float speed = 5;
    private void Start()
    {
        player = this.transform;
    }

    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        forwardDir = target.position - player.position;
        forwardDir.y = 0;
        player.rotation = Quaternion.LookRotation(forwardDir, Vector3.up);

        Vector3 moveDir = (player.right * axisX + player.forward * axisY)*speed;

        controller.Move(moveDir * Time.deltaTime);
    }

    void PlayerInput()
    {

    }
}
