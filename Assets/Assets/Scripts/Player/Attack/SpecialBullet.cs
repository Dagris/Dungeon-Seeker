using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour {

    public GameObject enemyBullet;
    public LayerMask mask;
    void Start()
    {
        enemyBullet = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 0.5f);
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

        if (collision.gameObject.tag == "Enemy")
        {
            //enemyBullet.GetComponent<EnemyStats>().enemySpecialDamage();
            Debug.Log("hitSPECIAL");
            Invoke("hideBullet", 0.05f);

        }


        //GameObject.FindGameObjectWithTag("Enemy").
    }
}
