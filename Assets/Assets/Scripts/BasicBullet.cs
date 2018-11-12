using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    public GameObject enemyBullet;

    void Start()
    {
        enemyBullet = GameObject.FindGameObjectWithTag("Enemy");
    }
	private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 1.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            enemyBullet.GetComponent<EnemyStats>().enemyDamage();
            Debug.Log("hit");
            Invoke("hideBullet", 0.1f);

        }
       

       //GameObject.FindGameObjectWithTag("Enemy").
    }
}
