using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    public GameObject enemyBullet;
    public Collider bulletCollider;
    public Collider playerCollider;
    public ParticleSystem bulletHit;
    public ParticleSystem bulletfx;

    void Start()
    {
        enemyBullet = GameObject.FindGameObjectWithTag("Enemy");
        bulletCollider = this.gameObject.GetComponent<Collider>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(); //Player.GetComponent<Collider>(); 
        
    }

    void Update()
    {
        Physics.IgnoreCollision(playerCollider, bulletCollider);
    }
	private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 1f);
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
        //bulletCollider.enabled = false;
        bulletfx.Stop();
        bulletHit.Play();
        if(collision.gameObject.tag == "Enemy")
        {
            enemyBullet.GetComponent<EnemyStats>().enemyGunDamage();
            Debug.Log("hitgun");
            Invoke("hideBullet", 1f);

        }

        else
        {

            Invoke("hideBullet", 1f);
        }
       

       //GameObject.FindGameObjectWithTag("Enemy").
    }
}
