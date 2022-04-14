using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	AudioController audioController;
	void Start()
	{
		audioController = GameObject.FindObjectOfType<AudioController>();

		Destroy(gameObject, 3);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			audioController.gameSounds[7].Play();
			Destroy(gameObject);
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
		}
        else
        {
			Destroy(gameObject);
        }
	}
}
