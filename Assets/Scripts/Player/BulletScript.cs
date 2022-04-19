using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	private void Start()
	{
		Destroy(gameObject, 3);
	}

	private void Update(){
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
		}
	}
}
