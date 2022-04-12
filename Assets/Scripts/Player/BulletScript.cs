using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	void Start()
	{
		Destroy(gameObject, 3);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
		}
        else
        {
			Destroy(gameObject);
        }
	}
}