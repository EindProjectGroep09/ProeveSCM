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

	private void Update(){

	}

	private void OnCollisionEnter(Collision collision)
	{

		Debug.Log(collision.gameObject);

		if (collision.gameObject.CompareTag("Enemy") && gameObject.tag == "Bullet")
		{
			audioController.gameSounds[7].Play();
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
			Destroy(gameObject);
		}
		else if(collision.gameObject.CompareTag("Player") && gameObject.tag == "Laser")
		{
			Destroy(gameObject);
			collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(15f);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
