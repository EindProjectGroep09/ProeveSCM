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
		if (collision.gameObject.CompareTag("Enemy"))
		{
			audioController.gameSounds[7].Play();
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(15f);
			Destroy(gameObject);
		}

		if(collision.gameObject.CompareTag("Player")){
			Destroy(gameObject);
			collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(15f);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
