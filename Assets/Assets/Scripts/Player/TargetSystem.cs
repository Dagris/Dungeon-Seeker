using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour {

    public bool isTargeting = false;
    public float speed = 6;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isTargeting = !isTargeting;
        }
        FindClosestEnemy();	
	}


    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyLockOn closestEnemy = null;
        EnemyLockOn[] allEnemies = GameObject.FindObjectsOfType<EnemyLockOn>();

        foreach (EnemyLockOn currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }

            if (isTargeting)
            {
               // Vector3 direction;
                //direction = new Vector3.up;
                Vector3 lockon;
                lockon =  new Vector3(closestEnemy.transform.position.x, transform.position.y, closestEnemy.transform.position.z);
                //(transform.LookAt(closestEnemy.transform);
                transform.LookAt(lockon);
                //transform.RotateAround(closestEnemy.transform.position, direction, speed);
            }

            if(closestEnemy != null)
            {
                Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            }
        }

        

        
    }


}
