using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	

	[Header("Health")]

    public int enemyHP;
	
	void Start () 
	{
		enemyHP = 100;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyHP <= 0)
		{
			enemyDead();
		}
	}



	 public void enemyDamage()
    {
        enemyHP --;
		Debug.Log("dmg");
       
    }

	void enemyDead()
	{
		Destroy(gameObject);
	}
}
